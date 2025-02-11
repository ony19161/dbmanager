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
    /* Uncomment the following class when testing with postgres*/
    //[Table("students")]
    //public class Student
    //{
    //    [Key]
    //    [Column("id")]
    //    public int Id { get; set; }

    //    [Column("name")]
    //    public string Name { get; set; }

    //    [Column("roll_no")]
    //    public int RollNo { get; set; }

    //    [Column("section")]
    //    public string Section { get; set; }

    //    [Column("birth_date")]
    //    public DateTime BirthDate { get; set; }

    //    [Column("blood_group")]
    //    public string BloodGroup { get; set; }

    //    [Column("created_by")]
    //    public int CreatedBy { get; set; }

    //    [Column("created_at")]
    //    public DateTime CreatedAt { get; set; }

    //    [Column("modified_by")]
    //    public int ModifiedBy { get; set; }

    //    [Column("modified_at")]
    //    public DateTime ModifiedAt { get; set; }


    //}

    [Table("Students")]
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int RollNo { get; set; }

        public string Section { get; set; }

        public DateTime BirthDate { get; set; }

        public string BloodGroup { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime ModifiedAt { get; set; }

    }
}
