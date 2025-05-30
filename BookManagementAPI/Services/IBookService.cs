using BookManagementAPI.Models;

namespace BookManagementAPI.Services
{
    public interface IBookService
    {
        IQueryable<Book> GetAll();
        Book GetById(int id);
        void Add(Book book);
        void Update(Book book);
        void Delete(int id);
        bool Exists(int id);
    }

}
