using BookManagementAPI.Data;
using BookManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagementAPI.Services
{
    public class BookService : IBookService
    {
        private readonly BookContext _context;
        public BookService(BookContext context) => _context = context;

        public IQueryable<Book> GetAll() => _context.Books.Include(b => b.Publisher);

        public Book GetById(int id) => _context.Books.Include(b => b.Publisher).FirstOrDefault(b => b.Id == id);

        public void Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void Update(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = GetById(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }

        public bool Exists(int id) => _context.Books.Any(b => b.Id == id);
    }

}
