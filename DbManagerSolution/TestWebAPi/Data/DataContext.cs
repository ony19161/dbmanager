using Microsoft.EntityFrameworkCore;
using TestWebAPi.Models;

namespace TestWebAPi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Student> Students => Set<Student>();

    }
}
