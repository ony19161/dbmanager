using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManager.Interfaces
{
    public interface IDbContext
    {
        Task<IDbConnection> CreateConnectionAsync();
        QueryFactory GetDb(IDbConnection connection);
    }
}
