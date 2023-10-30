using System.Data.Common;

namespace DbManager.Interfaces
{
    public interface IDbContext
    {
        Task<DbConnection> CreateConnectionAsync();
        // Add necessary function for efcore
    }
}
