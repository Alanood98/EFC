using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace companyORM
{
    public class Employee
    {
        [Key]
        public int SSN { get; set; }
        public string Name { get; set; }
        public DataType Bdate { get; set; }
        public string Address { get; set; }
        public bool sex { get; set; }
        public decimal salary { get; set; }


        [ForeignKey("department")]
        public int Dnumber { get; set; }
        public virtual Department department { get; set; }


        [ForeignKey("employee")]
        public int Super_ssn { get; set; }
        public virtual Employee employee { get; set; }

        [InverseProperty("employee")]
        public virtual ICollection<Works_On> Works_Ones { get; set; }
        public virtual ICollection<Employee> employees { get; set; }
        public virtual ICollection<Dependent> Dependentes { get; set; }

    }   
}
