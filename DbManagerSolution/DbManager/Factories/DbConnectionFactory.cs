using MySql.Data.MySqlClient;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace DbManager.Factories
{
    internal static class DbConnectionFactory
    {
        internal static DbConnection GetSqlServerConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }

        internal static DbConnection GetMySqlConnection(string connectionString)
        {
            return new MySqlConnection(connectionString);
        }

        internal static DbConnection GetSqliteConnection(string connectionString)
        {
            return new SQLiteConnection(connectionString);
        }

        internal static DbConnection GetPostgreSqlConnection(string connectionString)
        {
            return new NpgsqlConnection(connectionString);
        }
    }
}
