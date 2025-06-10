using DataLayer.Entities;
using DataLayer.DTOs;


namespace BusinessLayer.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<SystemAccount>> GetAllAsync();
        Task<SystemAccount?> GetByIdAsync(string id);
        Task CreateAsync(SystemAccount account);
        Task UpdateAsync(string id, UpdateAccountDto accountDto);
        Task DeleteAsync(string id);
    }
}