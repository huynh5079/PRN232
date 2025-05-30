using Lab02_ODataBookAPI.Models;
using System.Linq;

namespace Lab02_ODataBookAPI.Service
{
    public interface IBookService
    {
        IQueryable<Book> GetAll();
        Book GetById(int id);
        Book Add(Book book);
        Book Update(int id, Book book);
        bool Delete(int id);
    }
}
