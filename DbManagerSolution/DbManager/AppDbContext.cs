using DbManager.Interfaces;
using DbManager.Models;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManager
{
    public class AppDbContext : IDbContext
    {
        private readonly string connectionString;

        public AppDbContext(IOptions<ConnectionStrings> connectionsStringOptions)
        {
            connectionString = connectionsStringOptions.Value.DefaultConnection;
        }
        public async Task<IDbConnection> CreateConnectionAsync()
        {
            var mySqlConnection = new MySqlConnection(connectionString);
            await mySqlConnection.OpenAsync();
            return mySqlConnection;
        }

        public QueryFactory GetDb(IDbConnection connection)
        {
            return new QueryFactory(connection, new MySqlCompiler());
        }
    }
}
