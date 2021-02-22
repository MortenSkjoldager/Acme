using System;
using System.Collections.Generic;
using System.Linq;
using Acme.BusinessLogic.DataAccess;
using Acme.BusinessLogic.Model;
using Acme.Model;

namespace Acme.BusinessLogic.Submissions.Impl
{
    public class SubmissionService : ISubmissionService
    {
        public int GetActivationCount(Guid guid)
        {
            int activationCount = 0;
            
            using (var databaseContext = new DatabaseContext())
            {
                activationCount = databaseContext.Submissions.Count(x => x.SerialNumber.Key == guid);
            }

            return activationCount;
        }

        public IList<Submission> GetSubmissions(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public SubmissionCreationResult CreateSubmission(string firstName, string lastName, string email, Guid serialNumber)
        {
            var result = new SubmissionCreationResult();
            
            using (var context = new DatabaseContext())
            {
                var existingSerialNumber = context.SerialNumbers.FirstOrDefault(x => x.Key == serialNumber);
                if (existingSerialNumber == null)
                {
                    return new SubmissionCreationResult()
                    {
                        Success = false,
                        Message = "No serial number found matching your entry."
                    };
                }
                    
                var existingSubmissions = context.Submissions.Count(x => x.SerialNumber.Key == serialNumber);
                if (existingSubmissions == 2)
                {
                    return new SubmissionCreationResult()
                    {
                        Success = false,
                        Message = "You can only submit two entries per serial"
                    };
                }

                context.Submissions.Add(new Submission()
                {
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    SerialNumber = existingSerialNumber
                });

                context.SaveChanges();
            }
            
            return new SubmissionCreationResult()
            {
                Success = true
            };
        }
    }
}