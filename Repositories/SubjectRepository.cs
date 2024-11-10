using Microsoft.EntityFrameworkCore;
using CollegeDB;
using System.Collections.Generic;
using System.Linq;

namespace CollegeDB.Repositories
{
    public class SubjectRepository
    {
        private readonly AppDBcon _context;

        public SubjectRepository(AppDBcon context)
        {
            _context = context;
        }

        public List<Subject> GetAllSubjects()
        {
            return _context.Subjects
                .Include(s => s.faculty)
                .ToList();
        }

        public Subject GetSubjectById(int id)
        {
            return _context.Subjects
                .Include(s => s.faculty)
                .SingleOrDefault(s => s.Subject_id == id);
        }

        public void AddSubject(Subject subject)
        {
            _context.Subjects.Add(subject);
            _context.SaveChanges();
        }

        public void UpdateSubject(Subject subject)
        {
            _context.Subjects.Update(subject);
            _context.SaveChanges();
        }

        public void DeleteSubject(int id)
        {
            var subject = GetSubjectById(id);
            if (subject != null)
            {
                _context.Subjects.Remove(subject);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Subject> GetSubjectsTaughtByFaculty(int facultyId)
        {
            return _context.Subjects
                .Where(s => s.F_id == facultyId)
                .ToList();
        }

        public int CountSubjects()
        {
            return _context.Subjects.Count();
        }
    }
}
