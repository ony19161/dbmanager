using Demo.Dto.Response.Student;
using Demo.Repository.Interfaces;
using Demo.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service.Implementations
{
    public class StudentQueryService : IStudentQueryService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentQueryService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }


        public async Task<StudentInfo> GetStudentInfoAsync(object studentId)
        {
            var sStudent = await _studentRepository.GetByIdAsync(studentId);

            if (ReferenceEquals(sStudent, null))
                throw new KeyNotFoundException("Student not found");

            return new StudentInfo
            {
                Name = sStudent.Name,
                RollNo = sStudent.RollNo
            };
        }
    }
}
