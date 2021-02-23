using System;

namespace Acme.Model
{
    public class SubmissionRequestModel
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }
        
        public int Age { get; set; }
        
        public Guid SerialNumber { get; set; }
    }
}