using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManagerTest.Models
{
    public class Student
    {
        [Key]
        public string Id{ get; set; }
        public string Name{ get; set; }
        public string RollNo{ get; set; }
        public string Section{ get; set; }
        public string BirthDate{ get; set; }
        public string BloodGroup{ get; set; }
    }
}
