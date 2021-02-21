using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.BusinessLogic.DataAccess;
using Acme.BusinessLogic.Model;

namespace Acme.BusinessLogic.Test
{
    [TestFixture]
    public class DatabaseContextTest
    {
        [Test]
        public void CreateSerialNumberTest()
        {
            using (var context = new DatabaseContext())
            {
                context.SerialNumbers.Add(new SerialNumber()
                {
                    Key = Guid.NewGuid()
                });
                context.SaveChanges();
            }
        }
    }
}
