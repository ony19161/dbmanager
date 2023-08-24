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
using SqlKata.Compilers;

namespace DbManager.Factories
{
    internal static class SqlCompilerFactory
    {
        internal static Compiler GetSqlServerCompiler()
        {
            return new SqlServerCompiler();
        }

        internal static Compiler GetMySqlCompiler()
        {
            return new MySqlCompiler();
        }

        internal static Compiler GetSqliteCompiler()
        {
            return new SqliteCompiler();
        }

        internal static Compiler GetPostgreSqlCompiler()
        {
            return new PostgresCompiler();
        }
    }
}
