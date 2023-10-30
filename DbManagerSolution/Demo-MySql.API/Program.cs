using DbManager.Implementations;
using Demo.Repository.Implementations;
using Demo.Repository.Interfaces;
using Demo.Service.Implementations;
using Demo.Service.Interfaces;
using Demo.Service.Mappings;

namespace Demo_MySql.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>();

            builder.Services.AddScoped<IStudentRepository, StudentRepository>();
            builder.Services.AddScoped<IStudentQueryService, StudentQueryService>();

            // Auto mapper config
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}