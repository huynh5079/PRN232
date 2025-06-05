using DataLayer.Entities;

namespace DataLayer.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<SystemAccount>> GetAllAsync();
        Task<SystemAccount?> GetByIdAsync(string id);
        Task CreateAsync(SystemAccount account); 
        Task UpdateAsync(SystemAccount account, string? newPlainPassword = null); // New optional parameter for password change
        Task DeleteAsync(string id);
    }
}