namespace Acme.BusinessLogic.DataAccess
{
    public interface IDatabaseContextProvider
    {
        DatabaseContext GetDatabaseContext();
    }
}