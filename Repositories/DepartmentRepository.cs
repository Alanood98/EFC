using Microsoft.EntityFrameworkCore;
using CollegeDB;
using System.Collections.Generic;
using System.Linq;

namespace CollegeDB.Repositories
{
    public class DepartmentRepository
    {
        private readonly AppDBcon _context;

        public DepartmentRepository(AppDBcon context)
        {
            _context = context;
        }

        public List<Department> GetAllDepartments()
        {
            return _context.Departments
                .Include(d => d.Courses)
                .Include(d => d.Exams)
                .ToList();
        }

        public Department GetDepartmentById(int id)
        {
            return _context.Departments
                .Include(d => d.Courses)
                .Include(d => d.Exams)
                .SingleOrDefault(d => d.Department_id == id);
        }

        public void AddDepartment(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }

        public void UpdateDepartment(Department department)
        {
            _context.Departments.Update(department);
            _context.SaveChanges();
        }

        public void DeleteDepartment(int id)
        {
            var department = GetDepartmentById(id);
            if (department != null)
            {
                _context.Departments.Remove(department);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Department> GetDepartmentsWithCourses()
        {
            return _context.Departments
                .Where(d => d.Courses.Any())
                .ToList();
        }

        public IEnumerable<string> GetDepartmentNames()
        {
            return _context.Departments
                .Select(d => d.D_name)
                .ToList();
        }
    }
}
