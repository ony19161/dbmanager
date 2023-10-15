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

        /// <summary>
        ///  Deletes an entity from your respected database.
        /// </summary>
        /// <param name="entity">Your Entity(DB table) Class. ex: Student,Person etc</param>
        /// <returns></returns>
        public async Task<int> DeleteAsync(TEntity entity)
        {
           _dbSet.Remove(entity);
           return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Finds from your corresopnding Entity based on your provided predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public Task<IList<ReturnType>> FetchListBySPAsync<ReturnType, P>(string storedProcedureName, P parameters)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all data from the repected entity
        /// </summary>
        /// <returns></returns>
        public async Task<IList<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        /// <summary>
        /// Takes an Id then return the entity object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        /// <summary>
        /// Takes an entity object then inserts it into the table. (Entity)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> InsertAsync(TEntity entity)
        {
            _dbSet.Add(entity);
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Takes an entity then updates it from the database table
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<int> UpdateAsync(TEntity entity)
        {
            var obj = await _dbSet.FindAsync(entity.Id);

            if (obj is not null)
            {
                _context.Entry(entity).State = EntityState.Modified;

                return await _context.SaveChangesAsync();
            }
            return -1;
        }
    }
}
