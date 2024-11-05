using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeDB
{
    public class Hostel
    {
        [Key]
        public int Hostel_id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 12)]
        public string Hostel_name { get; set; }
        public int No_of_seats { get; set; }
   

        public virtual ICollection<Student> Students { get; set; }
    }

}
