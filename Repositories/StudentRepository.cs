using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CollegeDB.Repositories
{
    public class StudentRepository
    {
        private readonly AppDBcon _context;

        public StudentRepository(AppDBcon context)
        {
            _context = context;
        }

        // Fetch all students with associated details
        public List<Student> GetAll()
        {
            //return _context.Students
            //    .Include(s => s.Hostel)
            //    .Include(s => s.faculty)
            //    .Include(s => s.faculty.Department)
            //    .ToList();
            return _context.Students.ToList();
        }

        // Get student by ID with full navigational properties
        public Student GetById(int id)
        {
            return _context.Students
                .Include(s => s.Hostel)
                .Include(s => s.faculty)
                .Include(s => s.faculty.Department)
                .SingleOrDefault(s => s.S_id == id);
        }

        // Add new student
        public void Add(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        // Update existing student
        public void Update(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }

        // Delete student by ID
        public void Delete(int id)
        {
            var student = GetById(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }

        // Get students by enrolled course ID
        public IEnumerable<Student> GetStudentsByCourse(int courseId)
        {
            return _context.Students
                .Where(s => s.faculty.Subjects.Any(c => c.Subject_id == courseId))
                .ToList();
        }

        // Get students in a specific hostel
        public IEnumerable<Student> GetStudentsInHostel(int hostelId)
        {
            return _context.Students
                .Where(s => s.Hostel_id == hostelId)
                .ToList();
        }

        // Search students by name or phone number
        public IEnumerable<Student> SearchStudents(string searchTerm)
        {
            return _context.Students
                .Where(s => s.Name.Contains(searchTerm) || s.Phone_no.ToString().Contains(searchTerm))
                .ToList();
        }

        // Get students above a specific age
        public IEnumerable<Student> GetStudentsWithAgeAbove(int age)
        {
            var date = DateTime.Today.AddYears(-age);
            return _context.Students
                .Where(s => s.DOB <= date)
                .ToList();
        }

        // Paginate student results
        public IEnumerable<Student> PaginateStudents(int pageNumber, int pageSize)
        {
            return _context.Students
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
    }
}


