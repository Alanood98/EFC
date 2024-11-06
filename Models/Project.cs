using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace companyORM
{
    public class Project
    {
        [Key]
        public int Pnumber { get; set; }
        public string Pname { get; set; }
        public string Plocation { get; set; }

        [ForeignKey("department")]
        public int Dnumber { get; set; }
        public virtual Department department { get; set; }

        public virtual ICollection<Works_On> Works_Ones { get; set; }


    }
}
