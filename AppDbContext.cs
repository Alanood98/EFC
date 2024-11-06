using Microsoft.EntityFrameworkCore;
using companyORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace companyORM
{
    public class AppDBcon : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Data Source=(local);Initial Catalog=CompanyDDB;Integrated Security=true;TrustServerCertificate=True");
        }


        public DbSet<Employee> Employeese { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Dept_Location> Dept_Locationes { get; set; }
        public DbSet<Project> Projectes { get; set; }
        public DbSet<Works_On> Works_Ones { get; set; }
        public DbSet<Dependent> Dependentes { get; set; }
        

    }
}
