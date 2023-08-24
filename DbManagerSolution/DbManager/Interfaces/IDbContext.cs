using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManager.Interfaces
{
    public interface IDbContext
    {
        Task<DbConnection> CreateConnectionAsync();
        QueryFactory GetDb(DbConnection connection);
    }
}
