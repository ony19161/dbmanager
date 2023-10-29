using DbManager.Interfaces;
using DbManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Reflection;
using System.Security.Principal;

namespace DbManager.Implementations
{

    public class AppDbContext : DbContext
    {
        private readonly DbConnectionSettings dbConnectionSettings;

        protected readonly IConfiguration _configuration;
        private readonly string _entitiesAssemblyName;

        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _entitiesAssemblyName = _configuration.GetSection("EntitiesAssemblyName").Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Read the database connection string from your app's configuration
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            if (!string.IsNullOrEmpty(connectionString))
            {
                // Determine the database provider based on configuration
                var databaseProvider = _configuration.GetSection("DatabaseProvider").Value;

                if (databaseProvider == "SqlServer")
                {
                    optionsBuilder.UseSqlServer(connectionString);
                }
                else if (databaseProvider == "MySql")
                {
                    optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
                }
                else
                {
                    throw new NotSupportedException($"Database provider '{databaseProvider}' is not supported.");
                }
            }
            else
            {
                throw new InvalidOperationException("Database connection string is not configured.");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // You can add any further configuration here.
            AddDbSetForEntities(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        // Use reflection to add DbSet properties dynamically based on your configuration.
        private void AddDbSetForEntities(ModelBuilder modelBuilder)
        {
            // Load the specified assembly.
            var assembly = Assembly.Load(_entitiesAssemblyName);

            // Scan the assembly containing your entities.
            var entityTypes = assembly.GetTypes()
                .Where(type => type.GetCustomAttribute<TableAttribute>() != null && !type.IsAbstract);

            foreach (var entityType in entityTypes)
            {
                // You can use your configuration mechanism here to decide whether to include this entity.
                // For example, you could check for attributes, naming conventions, or a configuration file.
                // For simplicity, we'll include all entities here.
                modelBuilder.Entity(entityType);
            }
        }



    }
}
