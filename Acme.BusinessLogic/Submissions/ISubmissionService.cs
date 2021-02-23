using System;
using System.Collections.Generic;
using Acme.BusinessLogic.Model;
using Acme.Model;

namespace Acme.BusinessLogic.Submissions
{
    public interface ISubmissionService
    {
        int GetActivationCount(Guid guid);

        SubmissionQueryReponse GetSubmissions(int skip, int take);

        SubmissionCreationResult CreateSubmission(string firstName, string lastName, string email, int age, Guid serialNumber);
    }
}