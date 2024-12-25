using DbManager.Attributes;
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

    public class AppDbContext : DbContext, IDbContext
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
                else if (databaseProvider == "PostgreSQL")
                {
                    optionsBuilder.UseNpgsql(connectionString);
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
            AddDbSetForEntities(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        public void AddDbSetForEntities(ModelBuilder modelBuilder)
        {
            // Load the specified assembly.
            var assembly = Assembly.Load(_entitiesAssemblyName);

            // Scan the assembly containing your entities.
            var entityTypes = assembly.GetTypes()
                                      .Where(type => (type.GetCustomAttribute<TableAttribute>() != null ||
                                                      type.GetCustomAttribute<StoredProcedureAttribute>() != null) ||
                                                      typeof(IDbResult).IsAssignableFrom(type) &&
                                                      !type.IsAbstract);

            foreach (var entityType in entityTypes)
            {
                // Adding entity classes to the model builder for EF Core
                if (typeof(IDbResult).IsAssignableFrom(entityType))
                {
                    // If entity implements IDbResult, treat it as a result without a key
                    modelBuilder.Entity(entityType).HasNoKey().ToView(null);
                }
                else if (entityType.GetCustomAttribute<StoredProcedureAttribute>() != null)
                {
                    // If entity has StoredProcedureAttribute, treat it as a result without a key
                    modelBuilder.Entity(entityType).HasNoKey().ToView(null);
                }
                else
                {
                    modelBuilder.Entity(entityType);
                }
            }
        }



    }
}
