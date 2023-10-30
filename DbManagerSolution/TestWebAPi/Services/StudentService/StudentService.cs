using TestWebAPi.Dtos;
using TestWebAPi.Models;

namespace TestWebAPi.Services.StudentService
{
    public class StudentService : IStudentService
    {
        public Task<ServiceResponse<List<GetStudentDto>>> GetAllStudents()
        {
            throw new NotImplementedException();
        }
    }
}
