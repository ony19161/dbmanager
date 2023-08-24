using DbManager.Factories;
using DbManager.Interfaces;
using DbManager.Models;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using Npgsql;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var dbConnection = GetDbConnection(dbConnectionSettings);
            await dbConnection.OpenAsync();
            return dbConnection;
        }

        public QueryFactory GetDb(DbConnection connection)
        {
            return new QueryFactory(connection, GetDbCompiler(dbConnectionSettings.Provider));
        }

        private DbConnection GetDbConnection(DbConnectionSettings settings)
        {
            switch (settings.Provider)
            {
                case DbProvider.SQLSERVER:
                    return DbConnectionFactory.GetSqlServerConnection(settings.ConnectionString);

                case DbProvider.MYSQL:
                    return DbConnectionFactory.GetMySqlConnection(settings.ConnectionString);

                case DbProvider.SQLITE:
                    return DbConnectionFactory.GetSqliteConnection(settings.ConnectionString);

                case DbProvider.POSTGRESQL:
                    return DbConnectionFactory.GetPostgreSqlConnection(settings.ConnectionString);

                default:
                    throw new Exception("Database provider invalid");
            }
        }

        private Compiler GetDbCompiler(string provider)
        {
            switch (provider)
            {
                case DbProvider.SQLSERVER:
                    return SqlCompilerFactory.GetSqlServerCompiler();

                case DbProvider.MYSQL:
                    return SqlCompilerFactory.GetMySqlCompiler();

                case DbProvider.SQLITE:
                    return SqlCompilerFactory.GetSqliteCompiler();

                case DbProvider.POSTGRESQL:
                    return SqlCompilerFactory.GetPostgreSqlCompiler();

                default:
                    throw new Exception("Database provider invalid");
            }
        }
    }
}
