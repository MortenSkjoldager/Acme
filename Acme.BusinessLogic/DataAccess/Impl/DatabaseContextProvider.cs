namespace Acme.BusinessLogic.DataAccess.Impl
{
    public class DatabaseContextProvider : IDatabaseContextProvider
    {
        public virtual DatabaseContext GetDatabaseContext()
        {
            return new DatabaseContext();
        }
    }
}