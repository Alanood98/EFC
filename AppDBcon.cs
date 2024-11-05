using Microsoft.EntityFrameworkCore;
using CollegeDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CollegeDB
{
    public class AppDBcon : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Data Source=(local);Initial Catalog=CollegeStudentDB;Integrated Security=true;TrustServerCertificate=True");
        }


        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Exams> Exams { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Hostel> Hostels { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }

    }
}
