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
        Task<IEnumerable<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> predicate, int pageNo = 0, int pageSize = 0);
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<int> SaveChangesAsync();
        Task<ReturnType> GetScalerValueByQueryAsync<ReturnType>(FormattableString sqlQuery) where ReturnType : class;
        Task<List<ReturnType>> GetListByQueryAsync<ReturnType>(FormattableString sqlQuery) where ReturnType : class;
        Task<List<ReturnType>> ExecuteStoredProcedureAsync<ReturnType, P>(P parameters, string schema = "dbo") where ReturnType : class;
    }
}
