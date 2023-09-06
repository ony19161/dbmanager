using DbManager.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Db.Models
{
    [Table("Students")]
    public class Student : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int RollNo { get; set; }
        public string Section { get; set; }
        public string BirthDate { get; set; }
        public string BloodGroup { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }

    }
}
