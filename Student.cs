using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeDB
{
    public class Student
    {
        [Key]
        public int S_id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 12)]
        public string Name { get; set; }
        [Required]
        public int Phone_no { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string Address { get; set; } 
       
        

        public int Hostel_id { get; set; }
        [ForeignKey("Hostel_id")]
        public virtual Hostel Hostel { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Exams> Exams { get; set; }
    }

}
