using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Dto.Request
{
    public class StudentFilterRequest
    {
        public string BloodGroup { get; set; } = string.Empty;
        public string Section { get; set; } = string.Empty;
    }
}
