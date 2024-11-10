using Microsoft.EntityFrameworkCore;
using CollegeDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeDB.Repositories
{
    public class FacultyRepository
    {
        private readonly AppDBcon _context;

        public FacultyRepository(AppDBcon context)
        {
            _context = context;
        }

        public List<Faculty> GetAll()
        {
            return _context.Faculties
                .Include(f => f.Subjects)
                .ToList();
        }

        public Faculty GetById(int id)
        {
            return _context.Faculties
                .Include(f => f.Subjects)
                .SingleOrDefault(f => f.F_id == id);
        }

        public void Add(Faculty faculty)
        {
            _context.Faculties.Add(faculty);
            _context.SaveChanges();
        }

        public void Update(Faculty faculty)
        {
            _context.Faculties.Update(faculty);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var faculty = GetById(id);
            if (faculty != null)
            {
                _context.Faculties.Remove(faculty);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Faculty> GetFacultyByDepartment(int departmentId)
        {
            return _context.Faculties
                .Where(f => f.Department_id == departmentId)
                .ToList();
        }

        public decimal CalculateAverageSalary()
        {
            return _context.Faculties.Average(f => f.Salary);
        }
    }
}
