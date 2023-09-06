using DbManager.Interfaces;
using Demo.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Repository.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
    }
}
