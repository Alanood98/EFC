using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace companyORM
{
    public class Department
    {
        public string DName { get; set; }
        [Key]
        public int Dnumber { get; set; }
         
        public DataType Marg_start_date { get; set;}

        [ForeignKey("employee")]
        public int Marg_ssn { get; set; }
        public virtual Employee employee { get; set; }

        [InverseProperty("department")]
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Dept_Location> Dept_Locations { get; set; }


    }
}
