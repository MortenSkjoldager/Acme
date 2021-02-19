using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Acme.BusinessLogic.DataAccess;
using Acme.BusinessLogic.Model;

namespace Acme.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<SerialNumber> serialNumbers = new List<SerialNumber>();
            
            for (int i = 0; i < 100; i++)
            {
                serialNumbers.Add(new SerialNumber()
                {
                    Key = Guid.NewGuid()
                });    
            }
            
            Console.WriteLine("Saving generated keys to database.");
            using(var context = new DatabaseContext())
            {
                context.SerialNumbers.AddRange(serialNumbers);
                context.SaveChanges();
            }

            Console.WriteLine("Saving generated keys to text file.");
            System.IO.File.WriteAllLines("c:\\tmp\\serialnumbers.txt", serialNumbers.Select(x => x.Key.ToString()));
            
            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }
}