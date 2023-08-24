using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManager.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetById<IdType>(IdType id);
        Task<IList<TEntity>> GetAll();
        Task<int?> Insert(TEntity entity);
        Task<int> Update(TEntity entity);
        Task<int> Delete(TEntity entity);
        Task<IList<ReturnType>> FetchListByStoredProcedure<ReturnType, P>(string storedProcedureName, P parameters);

    }
}
