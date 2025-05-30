using BookManagementAPI.Models;

namespace BookManagementAPI.Services
{
    public interface IPublisherService
    {
        IQueryable<Publisher> GetAll();
        Publisher? GetById(int id);
        Publisher Add(Publisher publisher);
        void Update(Publisher publisher);
        void Delete(int id);
        bool Exists(int id);
    }

}
