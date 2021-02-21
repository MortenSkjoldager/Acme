using System;

namespace Acme.BusinessLogic.Submissions
{
    public interface ISubmissionService
    {
        int GetActivationCount(Guid guid);
    }
}