using DbManager.Attributes;
using DbManager.Interfaces;
using Microsoft.Data.SqlClient;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DbManager.Implementations
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        /// <summary>
        /// Finds from your corresopnding Entity based on your provided predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate,
            int pageNo = 0, int pageSize = 0)
        {
            if (pageNo ==  0 && pageSize == 0) 
                return await _dbSet.Where(predicate).ToListAsync();

            return await _dbSet.Where(predicate).Skip((pageNo - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync();
        }

        public async Task<List<ReturnType>> ExecuteStoredProcedureAsync<ReturnType, P>(P parameters, string schema = "dbo") where ReturnType : class
        {
            try
            {
                using (_context)
                {
                    var paramList = new List<SqlParameter>();

                    var storedProcedureAttribute = typeof(ReturnType).GetCustomAttributes<StoredProcedureAttribute>().FirstOrDefault();

                    foreach (var prop in parameters!.GetType().GetProperties())
                    {
                        paramList.Add(new SqlParameter(prop.Name, prop.GetValue(parameters)));
                    }

                    // Execute the stored procedure
                    var result = await _context.Set<ReturnType>()
                                               .FromSqlRaw($"EXEC {schema}.{storedProcedureAttribute.Name} {string.Join(", ", paramList.Select(p => $"@{p.ParameterName}"))}", paramList.ToArray())
                                               .ToListAsync();

                    return result;
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Get all data from the repected entity
        /// </summary>
        /// <returns></returns>
        public async Task<IList<TEntity>> GetAllAsync(int pageNo = 0, int pageSize = 0)
        {
            if (pageNo == 0 && pageSize == 0)
                return await _dbSet.ToListAsync();

            return await _dbSet.Skip((pageNo -1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync();
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
            using (_context)
            {
                _dbSet.Add(entity);
                return await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Takes an entity then updates it from the database table
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<int> UpdateAsync(TEntity entity)
        {
            using (_context)
            {
                PropertyInfo idProperty = entity.GetType().GetProperty("Id");

                if (!ReferenceEquals(idProperty, null))
                {
                    object idValue = idProperty.GetValue(entity);

                    var obj = await _dbSet.FindAsync(idValue);

                    if (obj is not null)
                    {
                        _context.Entry(obj).State = EntityState.Detached;
                        _context.Entry(entity).State = EntityState.Modified;

                        return await _context.SaveChangesAsync();
                    }
                }


                return -1;
            }
        }

        /// <summary>
        ///  Deletes an entity from your respected database.
        /// </summary>
        /// <param name="entity">Your Entity(DB table) Class. ex: Student,Person etc</param>
        /// <returns></returns>
        public async Task<int> DeleteAsync(TEntity entity)
        {
            using (_context)
            {
                _dbSet.Remove(entity);
                return await _context.SaveChangesAsync();
            }
            
        }

        public async Task<ReturnType> GetScalerValueByQueryAsync<ReturnType>(FormattableString sqlQuery) where ReturnType : class
        {
            using (_context)
            {
                if (sqlQuery is null)
                    throw new ArgumentNullException(nameof(sqlQuery));

                return await _context.Database
                        .SqlQuery<ReturnType>(sqlQuery).FirstOrDefaultAsync();
            }
                     
        }

        public async Task<List<ReturnType>> GetListByQueryAsync<ReturnType>(FormattableString sqlQuery) where ReturnType : class
        {
            using (_context)
            {
                if (sqlQuery is null)
                    throw new ArgumentNullException(nameof(sqlQuery));

                return await _context.Database
                        .SqlQuery<ReturnType>(sqlQuery).ToListAsync();
            }
            
        }

    }
}
