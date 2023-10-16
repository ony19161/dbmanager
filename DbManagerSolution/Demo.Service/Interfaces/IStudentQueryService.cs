using Demo.Db.Models;
using Demo.Dto.Request;
using Demo.Dto.Response.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service.Interfaces
{
    public interface IStudentQueryService
    {
        Task<StudentInfo> GetStudentInfoAsync(object studentId);

        Task<IList<StudentInfo>> GetStudentsByFilter(StudentFilterRequest filterRequest);

        Task<List<StudentInfo>> GetAllStudent();

        Task<List<StudentInfo>> DeleteStudent(int id);
        Task<int> AddStudentSevice(AddStudentDTO student);

        Task<int> UpdateStudentSevice(UpdateStudentDTO student);
    }
}
