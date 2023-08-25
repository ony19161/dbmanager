using DbManager.Factories;
using DbManager.Interfaces;
using DbManager.Models;
using Microsoft.Extensions.Options;
using System.Data.Common;

namespace DbManager.Implementations
{

    public class AppDbContext : IDbContext
    {
        private readonly DbConnectionSettings dbConnectionSettings;

        public AppDbContext(IOptions<DbConnectionSettings> connectionsStringOptions)
        {
            dbConnectionSettings = connectionsStringOptions.Value;
        }
        public async Task<DbConnection> CreateConnectionAsync()
        {
            throw new NotImplementedException();
        }


        // Update for efcore
        /*public QueryFactory GetDb(DbConnection connection)
        {
            return new QueryFactory(connection, GetDbCompiler(dbConnectionSettings.Provider));
        }*/

        //update for efcore
        /*private DbConnection GetDbConnection(DbConnectionSettings settings)
        {
            
            
        }*/

       
    }
}
