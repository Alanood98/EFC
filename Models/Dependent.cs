using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace companyORM
{
    [PrimaryKey(nameof(ESSN), nameof(Dependent_name))]
    public class Dependent
    {
        [ForeignKey("employee")]
        public int ESSN { get; set; }
        public virtual Employee employee { get; set; }
        public string Dependent_name { get; set; }
        public bool sex { get; set; }
        public DataType Bdate { get; set; }



 
    }
}
