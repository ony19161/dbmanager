using DbManager.Interfaces;
using DbManagerTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManagerTest.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
    }
}
