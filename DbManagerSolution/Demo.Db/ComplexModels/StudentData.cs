using DbManager.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Db.ComplexModels
{
    [StoredProcedure("GetStudentsByFilter")]
    public class StudentData
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int RollNo { get; set; }
        public string Section { get; set; }
        public string BirthDate { get; set; }
        public string BloodGroup { get; set; }
    }
}
