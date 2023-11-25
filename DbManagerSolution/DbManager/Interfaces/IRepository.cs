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
        Task<IList<TEntity>> GetAllAsync(int pageNo = 0, int pageSize = 0);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, int pageNo = 0, int pageSize = 0);
        Task<int> InsertAsync(TEntity entity);
        Task<int> UpdateAsync(TEntity entity);
        Task<int> DeleteAsync(TEntity entity);
        Task<List<TEntity>> FetchListBySPAsync<ReturnType, P>(string storedProcedureName, P parameters);
    }
}
