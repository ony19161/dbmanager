using DbManager.Interfaces;
using SqlKata.Execution;
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

        public async Task<IList<TEntity>> GetAllAsync()
        {
            using var dbConnection = await dbContext.CreateConnectionAsync();
            var dbSet = GetDbSet(dbConnection);

            var resultSet = await dbSet.GetAsync<TEntity>();
            return resultSet.ToList();
        }

        public async Task<TEntity> GetByIdAsync<IdType>(IdType id)
        {
            using var dbConnection = await dbContext.CreateConnectionAsync();
            var dbSet = GetDbSet(dbConnection);

            return await dbSet.Where("Id", id).FirstOrDefaultAsync<TEntity>();
        }

        public async Task<int> InsertAsync(TEntity entity)
        {
            using var dbConnection = await dbContext.CreateConnectionAsync();
            var dbSet = GetDbSet(dbConnection);

            return await dbSet.InsertAsync(entity); 
        }

        public Task<int> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IList<ReturnType>> FetchListBySPAsync<ReturnType, P>(string storedProcedureName, P parameters)
        {
            throw new NotImplementedException();
        }
    }
}
