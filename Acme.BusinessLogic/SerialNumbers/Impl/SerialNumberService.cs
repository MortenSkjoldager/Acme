using System;
using System.Linq;
using Acme.BusinessLogic.DataAccess;
using Acme.BusinessLogic.Services;

namespace Acme.BusinessLogic.SerialNumbers.Impl
{
    public class SerialNumberService : ISerialNumberService
    {
        private readonly IDatabaseContextProvider _databaseContextProvider;

        public SerialNumberService(IDatabaseContextProvider databaseContextProvider)
        {
            _databaseContextProvider = databaseContextProvider;
        }
        public bool ValidateSerialNumber(Guid serialNumber)
        {
            var serialNumberValid = false;

            using (var databaseContext = _databaseContextProvider.GetDatabaseContext())
            {
                serialNumberValid = databaseContext.SerialNumbers.Any(x => x.Key == serialNumber);
            }
            
            return serialNumberValid;
        }
    }
}