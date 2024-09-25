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
        Task<ReturnType> GetScalerValueByQueryAsync<ReturnType>(FormattableString sqlQuery) where ReturnType : class;
        Task<List<ReturnType>> GetListByQueryAsync<ReturnType>(FormattableString sqlQuery) where ReturnType : class;
        Task<List<ReturnType>> ExecuteStoredProcedureAsync<ReturnType, P>(P parameters, string schema = "dbo") where ReturnType : class;
    }
}
