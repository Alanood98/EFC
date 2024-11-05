using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeDB
{
    public class Course
    {
        [Key]
        public int Course_id { get; set; }
        [Required]
        public string Course_name { get; set; }
        public string Duration { get; set; }
        [Required]
        public int Department_id { get; set; }
        [ForeignKey("Department_id")]
        public virtual Department Department { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Faculty> Faculties { get; set; }
    }

}
