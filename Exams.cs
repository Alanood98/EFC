using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeDB
{
    public class Exams
    {
        [Key]
        public int Exam_code { get; set; }
        public int Room { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }

}
