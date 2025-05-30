using Lab02_ODataBookAPI.Models;

namespace Lab02_ODataBookAPI.Service
{
    public interface IPressService
    {
        IQueryable<Press> GetAll();
        Press GetById(int id);
        Press Add(Press press);
        Press Update(int id, Press press);
        bool Delete(int id);
    }
}
