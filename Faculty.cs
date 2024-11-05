using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeDB
{
    public class Faculty
    {
        [Key]
        public int F_id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 12)]
        public string Name { get; set; }

        [Required]
        public string Department { get; set; }
        public int Mobile_no { get; set; }
        [Required]
        public decimal Salary { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
