using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Acme.BusinessLogic.DataAccess;
using Acme.BusinessLogic.Model;
using Acme.Model;

namespace Acme.BusinessLogic.Submissions.Impl
{
    public class SubmissionService : ISubmissionService
    {
        private readonly IDatabaseContextProvider _databaseContextProvider;

        public SubmissionService(IDatabaseContextProvider databaseContextProvider)
        {
            _databaseContextProvider = databaseContextProvider;
        }
        public int GetActivationCount(Guid guid)
        {
            int activationCount = 0;
            
            using (var databaseContext = _databaseContextProvider.GetDatabaseContext())
            {
                activationCount = databaseContext.Submissions.Count(x => x.SerialNumber.Key == guid);
            }

            return activationCount;
        }

        public SubmissionQueryReponse GetSubmissions(int skip, int take)
        {
            var queryResponse = new SubmissionQueryReponse();
            queryResponse.Skip = skip;
            queryResponse.Take = take;
            
            using (var databaseContext = _databaseContextProvider.GetDatabaseContext())
            {
                queryResponse.TotalCount = databaseContext.Submissions.Count();
                queryResponse.Submissions = databaseContext.Submissions
                    .OrderByDescending(x => x.Id)
                    .Skip(skip)
                    .Take(take)
                    .Include(x => x.SerialNumber)
                    .ToList();
            }
            
            return queryResponse;
        }

        public SubmissionCreationResult CreateSubmission(string firstName, string lastName, string email, int age, Guid serialNumber)
        {
            if (age < 18)
            {
                return new SubmissionCreationResult()
                {
                    Success = false,
                    Message = Constants.ErrorMessages.AgeLimit
                };
            }
            using (var databaseContext = _databaseContextProvider.GetDatabaseContext())
            {
                var existingSerialNumber = databaseContext.SerialNumbers.FirstOrDefault(x => x.Key == serialNumber);
                if (existingSerialNumber == null)
                {
                    return new SubmissionCreationResult()
                    {
                        Success = false,
                        Message = Constants.ErrorMessages.InvalidKey
                    };
                }
                    
                var existingSubmissions = databaseContext.Submissions.Count(x => x.SerialNumber.Key == serialNumber);
                if (existingSubmissions == 2)
                {
                    return new SubmissionCreationResult()
                    {
                        Success = false,
                        Message = Constants.ErrorMessages.OnlyEnterTwiceMessage
                    };
                }

                databaseContext.Submissions.Add(new Submission()
                {
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    SerialNumber = existingSerialNumber
                });

                databaseContext.SaveChanges();
            }
            
            return new SubmissionCreationResult()
            {
                Success = true
            };
        }
    }
}