using System;
using System.Linq;
using Acme.BusinessLogic.DataAccess;

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
    }
}