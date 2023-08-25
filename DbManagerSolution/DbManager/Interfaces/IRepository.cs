using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManager.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync<IdType>(IdType id);
        Task<IList<TEntity>> GetAllAsync();
        Task<int> InsertAsync(TEntity entity);
        Task<int> UpdateAsync(TEntity entity);
        Task<int> DeleteAsync(TEntity entity);
        Task<IList<ReturnType>> FetchListBySPAsync<ReturnType, P>(string storedProcedureName, P parameters);

    }
}
