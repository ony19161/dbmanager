using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Dto.Request
{
    public class UpdateStudentDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? RollNo { get; set; }
        public string? Section { get; set; }
        public string? BirthDate { get; set; }
        public string? BloodGroup { get; set; }
    }
}
