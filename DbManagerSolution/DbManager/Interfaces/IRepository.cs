using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DbManager.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(object id);
        Task<IList<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<int> InsertAsync(TEntity entity);
        Task<int> UpdateAsync(TEntity entity);
        Task<int> DeleteAsync(TEntity entity);
        Task<IList<ReturnType>> FetchListBySPAsync<ReturnType, P>(string storedProcedureName, P parameters);
    }
}
