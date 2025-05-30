using Lab02_ODataBookAPI.Data;
using Lab02_ODataBookAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Lab02_ODataBookAPI.Service
{
    public class BookService : IBookService
    {
        private readonly LibraryContext _context;

        public BookService(LibraryContext context)
        {
            _context = context;
        }

        public IQueryable<Book> GetAll()
        {
            return _context.Books.Include(b => b.Press);
        }

        public Book GetById(int id)
        {
            return _context.Books.Include(b => b.Press).FirstOrDefault(b => b.BookId == id);
        }

        public Book Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return book;
        }

        public Book Update(int id, Book book)
        {
            var existing = _context.Books.Find(id);
            if (existing == null) return null;

            existing.Title = book.Title;
            existing.Author = book.Author;
            existing.Price = book.Price;
            existing.PressId = book.PressId;

            _context.SaveChanges();
            return existing;
        }

        public bool Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null) return false;

            _context.Books.Remove(book);
            _context.SaveChanges();
            return true;
        }
    }

}
