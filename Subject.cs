using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeDB
{
    public class Subject
    {
        [Key]
        public int Subject_id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 12)]
        public string Subject_name { get; set; }

        public virtual ICollection<Faculty> Faculties { get; set; }
    }

}
