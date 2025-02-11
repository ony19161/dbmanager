using DbManager.Interfaces;
using Demo.Db.ComplexModels;
using Demo.Db.Models;
using Demo.Dto.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Repository.Interfaces
{
    public interface IStudentRepository : IRepository<Student>, ISaveChanges
    {
        Task<List<StudentData>> GetStudents(StudentFilterRequest filters);
        Task<ScalerData<int>> GetTotalStudentCount();
    }
}
