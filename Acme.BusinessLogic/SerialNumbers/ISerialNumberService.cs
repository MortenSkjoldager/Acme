using System;

namespace Acme.BusinessLogic.Services
{
    public interface ISerialNumberService
    {
        bool ValidateSerialNumber(Guid serialNumber);
    }
    
    
}