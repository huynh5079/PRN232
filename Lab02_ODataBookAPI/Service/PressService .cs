using Lab02_ODataBookAPI.Data;
using Lab02_ODataBookAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Lab02_ODataBookAPI.Service
{
    public class PressService : IPressService
    {
        private readonly LibraryContext _context;

        public PressService(LibraryContext context)
        {
            _context = context;
        }

        public IQueryable<Press> GetAll()
        {
            return _context.Presses.Include(p => p.Address).Include(p => p.Books);
        }

        public Press GetById(int id)
        {
            return _context.Presses.Include(p => p.Address).Include(p => p.Books)
                .FirstOrDefault(p => p.PressId == id);
        }

        public Press Add(Press press)
        {
            _context.Presses.Add(press);
            _context.SaveChanges();
            return press;
        }

        public Press Update(int id, Press press)
        {
            var existing = _context.Presses.Find(id);
            if (existing == null) return null;

            existing.Name = press.Name;
            existing.Category = press.Category;
            existing.AddressId = press.AddressId;

            _context.SaveChanges();
            return existing;
        }

        public bool Delete(int id)
        {
            var press = _context.Presses.Find(id);
            if (press == null) return false;

            _context.Presses.Remove(press);
            _context.SaveChanges();
            return true;
        }
    }

}
