using AutoMapper;
using Demo.Db.Models;
using Demo.Dto.Request;
using Demo.Dto.Response.Student;
using Demo.Repository.Interfaces;
using Demo.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service.Implementations
{
    public class StudentQueryService : IStudentQueryService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentQueryService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }


        public async Task<StudentInfo> GetStudentInfoAsync(object studentId)
        {
            var sStudent = await _studentRepository.GetByIdAsync(studentId);

            if (ReferenceEquals(sStudent, null))
                throw new KeyNotFoundException("Student not found");

            return _mapper.Map<StudentInfo>(sStudent);
        }

        public async Task<List<StudentInfo>> GetAllStudent()
        {
            var sStudent = await _studentRepository.GetAllAsync();

            return sStudent.Select(s => _mapper.Map<StudentInfo>(s)).ToList();
        }
        public async Task<IList<StudentInfo>> GetStudentsByFilter(StudentFilterRequest filterRequest)
        {
            Expression<Func<Student, bool>> predicates = s => s.BloodGroup.ToLower().Equals(filterRequest.BloodGroup.ToLower()) ||
                                                              s.Section.ToLower().Equals(filterRequest.Section.ToLower());
                        

            var sStudents = await _studentRepository.FindAsync(predicates);

            if (ReferenceEquals(sStudents, null))
                throw new KeyNotFoundException("Students not found");

            return _mapper.Map<IList<StudentInfo>>(sStudents.ToList());
        }
    }
}
