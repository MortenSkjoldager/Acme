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
}