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
    [Table("students")]
    public class Student
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("roll_no")]
        public int RollNo { get; set; }

        [Column("section")]
        public string Section { get; set; }

        [Column("birth_date")]
        public DateTime BirthDate { get; set; }

        [Column("blood_group")]
        public string BloodGroup { get; set; }

        [Column("created_by")]
        public int CreatedBy { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("modified_by")]
        public int ModifiedBy { get; set; }

        [Column("modified_at")]
        public DateTime ModifiedAt { get; set; }


    }
}
