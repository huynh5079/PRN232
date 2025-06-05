using DataLayer.Entities;

namespace NguyenManhTanHuynh_SE17D05_A01_BE.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<SystemAccount>> GetAllAsync();
        Task<SystemAccount> GetByIdAsync(string id);
        Task CreateAsync(SystemAccount account);
        Task UpdateAsync(SystemAccount account);
        Task DeleteAsync(string id);
    }
}
