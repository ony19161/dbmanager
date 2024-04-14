using DbManager.Implementations;
using Demo.Db.ComplexModels;
using Demo.Db.Models;
using Demo.Dto.Request;
using Demo.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Repository.Implementations
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<StudentData>> GetStudents(StudentFilterRequest filters)
        {
            var result = await base.ExecuteStoredProcedureAsync<StudentData, StudentFilterRequest>(filters);


            return result;
        }
    }
}
