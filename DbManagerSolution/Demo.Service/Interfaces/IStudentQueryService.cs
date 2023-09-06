﻿using Demo.Dto.Response.Student;
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
    }
}