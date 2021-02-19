using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Acme.BusinessLogic.Model;

namespace Acme.BusinessLogic.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Submission> Submissions { get; set; }

        public DbSet<SerialNumber> SerialNumbers { get; set; }

        public DatabaseContext() : base("DatabaseContext")
        {
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}