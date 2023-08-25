using DbManager.Implementations;
using DbManager.Interfaces;
using DbManagerTest.Interfaces;
using DbManagerTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManagerTest.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}
