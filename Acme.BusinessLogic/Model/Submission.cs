using System;

namespace Acme.BusinessLogic.Model
{
    public class Submission
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }
        
        public SerialNumber SerialNumber { get; set; }
    }

    public class SerialNumber
    {
        public int Id { get; set; }
        
        public Guid Key { get; set; }
    }
}