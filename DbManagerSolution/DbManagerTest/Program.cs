using DbManagerTest.Interfaces;
using DbManagerTest.Models;
using DbManagerTest.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DbManagerTest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using IHost host = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.confi
                    services.AddScoped<IStudentRepository, StudentRepository>();
                })
                .Build();

            var students = host.Services.GetService<StudentRepository>();
            var insertedId = await students!.InsertAsync(new Student 
            {
                Name = "Umar Mannaf",
                RollNo = "01",
                BloodGroup = "A+",
                BirthDate = "01/01/1989",
                Section = "C"
            });

            await host.RunAsync();
            Console.WriteLine("DbManager Test Completed!!!");
        }
    }
}