using BookManagementAPI.Data;
using BookManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagementAPI.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly BookContext _context;

        public PublisherService(BookContext context)
        {
            _context = context;
        }

        public IQueryable<Publisher> GetAll()
        {
            return _context.Publishers.Include(p => p.Books);
        }

        public Publisher? GetById(int id)
        {
            return _context.Publishers.Include(p => p.Books).FirstOrDefault(p => p.Id == id);
        }

        public Publisher Add(Publisher publisher)
        {
            _context.Publishers.Add(publisher);
            _context.SaveChanges();
            return publisher;
        }

        public void Update(Publisher publisher)
        {
            _context.Publishers.Update(publisher);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var publisher = GetById(id);
            if (publisher != null)
            {
                _context.Publishers.Remove(publisher);
                _context.SaveChanges();
            }
        }

        public bool Exists(int id)
        {
            return _context.Publishers.Any(p => p.Id == id);
        }
    }
}
