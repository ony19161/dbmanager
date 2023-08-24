using DbManager.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DbManager.Implementations
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public readonly IDbContext dbContext;
        public readonly string tableName;

        public BaseRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.tableName = GetTablename();
        }

        public SqlKata.Query GetDbSet(DbConnection dbConnection)
        {
            var db = dbContext.GetDb(dbConnection);
            return db.Query(GetTablename());
        }

        public SqlKata.Query GetDbSet<T>(DbConnection dbConnection)
        {
            var db = dbContext.GetDb(dbConnection);
            return db.Query(GetTablename<T>());
        }

        private string GetTablename()
        {
            Type entityType = typeof(TEntity);
            var tableAttribute = entityType.GetCustomAttribute<TableAttribute>();
            return tableAttribute.Name;

        }


        public string GetTablename<T>()
        {
            Type _entityType = typeof(T);
            var tableAttribute = _entityType.GetCustomAttribute<TableAttribute>();
            return tableAttribute.Name;
        }

        public Task<IList<TEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetById<IdType>(IdType id)
        {
            throw new NotImplementedException();
        }

        public Task<int?> Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IList<ReturnType>> FetchListByStoredProcedure<ReturnType, P>(string storedProcedureName, P parameters)
        {
            throw new NotImplementedException();
        }
    }
}
