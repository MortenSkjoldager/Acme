using System;
using System.Linq;
using Acme.BusinessLogic.DataAccess;
using Acme.BusinessLogic.Services;

namespace Acme.BusinessLogic.SerialNumbers.Impl
{
    public class SerialNumberService : ISerialNumberService
    {
        public bool ValidateSerialNumber(Guid serialNumber)
        {
            var serialNumberValid = false;

            using (var databaseContext = new DatabaseContext())
            {
                serialNumberValid = databaseContext.SerialNumbers.Any(x => x.Key == serialNumber);
            }
            
            return serialNumberValid;
        }
    }
}