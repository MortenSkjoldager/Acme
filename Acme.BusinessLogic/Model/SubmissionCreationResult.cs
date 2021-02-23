using System.Collections.Generic;
using Acme.BusinessLogic.Model;

namespace Acme.Model
{
    public class SubmissionCreationResult
    {
        public SubmissionCreationResult()
        {
            Message = "OK";
        }
        /// <summary>
        /// Indicates if the creation was successful or not.
        /// </summary>
        public bool Success { get; set; }
        
        /// <summary>
        /// Message 
        /// </summary>
        /// <returns>OK if Success is True, otherwise detailed description of error.</returns>
        public string Message { get; set; }
    }

    public class SubmissionQueryRequest
    {
        
    }

    public class SubmissionQueryReponse
    {
        public int TotalCount { get; set; }
        
        public int Skip { get; set; }
        
        public int Take { get; set; }
        
        public IList<Submission> Submissions { get; set; }
    }
}