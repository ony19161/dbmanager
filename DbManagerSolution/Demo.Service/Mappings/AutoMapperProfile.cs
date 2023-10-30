using AutoMapper;
using Demo.Db.Models;
using Demo.Dto.Request;
using Demo.Dto.Response.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Student, StudentInfo>().ReverseMap();
            CreateMap<UpdateStudentDTO, Student>().ReverseMap();
            CreateMap<AddStudentDTO, Student>().ReverseMap();
        }
    }
}
