using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace companyORM
{
    [PrimaryKey(nameof(ESSN), nameof(Pnumber))]
    public class Works_On

    {
        public decimal Hours { get; set; }

        [ForeignKey("employee")]
        public int ESSN { get; set; }
        public virtual Employee employee { get; set; }


        [ForeignKey("project")]
        public int Pnumber { get; set; }
        public virtual Project project { get; set; }
    }
}
