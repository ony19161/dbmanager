using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace DbManager.Interfaces
{
    public interface IDbContext
    {
        void AddDbSetForEntities(ModelBuilder modelBuilder);
    }
}
