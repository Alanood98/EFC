using Microsoft.EntityFrameworkCore;
using CollegeDB;
using System.Collections.Generic;
using System.Linq;

namespace CollegeDB.Repositories
{
    public class CourseRepository
    {
        private readonly AppDBcon _context;

        public CourseRepository(AppDBcon context)
        {
            _context = context;
        }

        public List<Course> GetAllCourses()
        {
            return _context.Courses
                .Include(c => c.Students)
                .Include(c => c.Faculties)
                .ToList();
        }

        public Course GetCourseById(int id)
        {
            return _context.Courses
                .Include(c => c.Students)
                .Include(c => c.Faculties)
                .SingleOrDefault(c => c.Course_id == id);
        }

        public void AddCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public void UpdateCourse(Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();
        }

        public void DeleteCourse(int id)
        {
            var course = GetCourseById(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Course> GetCoursesByDepartment(int departmentId)
        {
            return _context.Courses
                .Where(c => c.Department_id == departmentId)
                .ToList();
        }

        public IEnumerable<Course> GetCoursesWithDuration(string duration)
        {
            return _context.Courses
                .Where(c => c.Duration == duration)
                .ToList();
        }

        public IEnumerable<Course> PaginateCourses(int pageNumber, int pageSize)
        {
            return _context.Courses
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
    }
}
