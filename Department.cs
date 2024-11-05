using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeDB
{
    public class Department
    {
        [Key]
        public int Department_id { get; set; }
        public string D_name { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Exams> Exams { get; set; }
    }

}
