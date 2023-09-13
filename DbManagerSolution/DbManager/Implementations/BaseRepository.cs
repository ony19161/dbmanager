using DbManager.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DbManager.Implementations
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<int> DeleteAsync(TEntity entity)
        {
           _dbSet.Remove(entity);
           return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public Task<IList<ReturnType>> FetchListBySPAsync<ReturnType, P>(string storedProcedureName, P parameters)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<int> InsertAsync(TEntity entity)
        {
            _dbSet.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public Task<int> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
