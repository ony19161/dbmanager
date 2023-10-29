# Simplify Your .NET Project with DbManager
DbManager is a powerful package that simplifies the integration of CRUD (Create, Read, Update, Delete) operations in your .NET projects. It seamlessly supports various database systems like MS SQL Server, MySQL, and allows you to choose between Entity Framework or Dapper as your preferred data access technology.

# Getting Started
Integrating DbManager into your project is as easy as 1-2-3-4:

# Step 1: Add Project Reference
Begin by adding DbManager to your solution as a project reference.

# Step 2: Register Database Context
In your Program.cs file, register the AppDbContext class of DbManager library:

    var builder = WebApplication.CreateBuilder(args);
    // Add services to the container.
    builder.Services.AddDbContext<AppDbContext>();
    // now you can call your build method
    var app = builder.Build();

# Step 3: Configure Connection Strings
In your appsettings.json file, configure the connection strings based on your database provider and entities project:

For MS SQL Server:

    {
      "DatabaseProvider": "SqlServer",
      "EntitiesAssemblyName": "Demo.Db", // Assembly name where you have your Entity classes
      "ConnectionStrings": {
         "DefaultConnection": "Server=DESKTOP-8L9RIOK;Database=adventureworks;Integrated Security=true;TrustServerCertificate=True;MultipleActiveResultSets=true;"
      }
    }

For MySQL:

    {
      "DatabaseProvider": "MySql",
      "EntitiesAssemblyName": "Demo.Db",
      "ConnectionStrings": {
         "DefaultConnection": "your_mysql_connection_string_here"
      }
    }
# Step 5: Add entity class/classes

    [Table("Students")]
    public class Student
    {
       [Key]
       public int Id { get; set; }
       public string Name { get; set; }
       public int RollNo { get; set; }
       public string Section { get; set; }
       public string BirthDate { get; set; }
       public string BloodGroup { get; set; }
    }

 - You must mark your entity classes with [Table] annotation, otherwise "DbManager", will not be able to include them to the DbContext.
   
# Step 4: Inject DbManager into Your Classes
Inject the AppDbContext class into your desired Controller, Business, or Repository class. For example, in a StudentRepository class:

    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
       public StudentRepository(AppDbContext context) : base(context)
       {
       }
    }

    -----------------------------------------------------------------------------

    public interface IStudentRepository : IRepository<Student>
     {
     }
     

 - In above code, BaseRepository is from "DbManager" library, and IStudentRepository must inherit from "IRepository" of "DbManager" library.
   

     

   
# Utilize Pre-defined CRUD Operations
With DbManager integrated into your project, you can take advantage of all the CRUD methods already defined in the BaseRepository class. Here is a quick overview:

* `DeleteAsync` : Delete a single entity object.
* `FindAsync` : Find a single entity based on a provided predicate.
* `FetchListBySPAsync`: Fetch a list of entities using a stored procedure and parameters.
* `GetAllAsync`: Get all entity objects.
* `GetByIdAsync`: Retrieve an entity object based on its ID.
* `InsertAsync`: Insert a new entity object into the database.
* `UpdateAsync`: Update an existing entity object.
  

Remember, all methods are asynchronous, so ensure you use async/await properly while calling them.

**Congratulations! You've successfully configured DbManager for your project!**

For more detailed information and usage examples, refer to our documentation.

**Note:** Make sure to add a project reference to DbManager in your solution to access the **`BaseRepository`** class and other utilities. For any queries or issues, please reach out to our support team.

Happy Coding with DbManager!
   
