using Microsoft.EntityFrameworkCore;
using CollegeDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeDB.Repositories
{
    public class HostelRepository
    {
        private readonly AppDBcon _context;

        public HostelRepository(AppDBcon context)
        {
            _context = context;
        }

        public List<Hostel> GetAll()
        {
            return _context.Hostels
                .Include(h => h.Students)
                .ToList();
        }

        public Hostel GetById(int id)
        {
            return _context.Hostels
                .Include(h => h.Students)
                .SingleOrDefault(h => h.Hostel_id == id);
        }

        public void Add(Hostel hostel)
        {
            _context.Hostels.Add(hostel);
            _context.SaveChanges();
        }

        public void Update(Hostel hostel)
        {
            _context.Hostels.Update(hostel);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var hostel = GetById(id);
            if (hostel != null)
            {
                _context.Hostels.Remove(hostel);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Hostel> GetHostelsByCity(string city)
        {
            return _context.Hostels
                .Where(h => h.Hostel_name.Contains(city))
                .ToList();
        }

        public int CountHostelsWithAvailableSeats()
        {
            return _context.Hostels.Count(h => h.No_of_seats > 0);
        }
    }
}
