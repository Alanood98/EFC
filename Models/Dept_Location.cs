using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace companyORM
{
    [PrimaryKey(nameof(Dnumber), nameof(Dlocation))]
    public class Dept_Location
    {
        [ForeignKey("department")]
        public int Dnumber { get; set; }
        public virtual Department department { get; set; }


     public string Dlocation {  get; set; }
    }
}


