using DataLayer.Entities;
using NguyenManhTanHuynh_SE17D05_A01_BE.Repositories;

namespace NguyenManhTanHuynh_SE17D05_A01_BE.Services
{
    public class AccountService : IAccountService
    {
        private readonly IGenericRepository<SystemAccount> _accountRepository;
        private readonly IGenericRepository<NewsArticle> _newsArticleRepository;

        public AccountService(IGenericRepository<SystemAccount> accountRepository, IGenericRepository<NewsArticle> newsArticleRepository)
        {
            _accountRepository = accountRepository;
            _newsArticleRepository = newsArticleRepository;
        }

        public async Task<IEnumerable<SystemAccount>> GetAllAsync()
        {
            return await _accountRepository.GetAllAsync();
        }

        public async Task<SystemAccount> GetByIdAsync(string id)
        {
            return await _accountRepository.GetAsync(a => a.Id == id);
        }

        public async Task CreateAsync(SystemAccount account)
        {
            await _accountRepository.CreateAsync(account);
            await _accountRepository.SaveAsync();
        }

        public async Task UpdateAsync(SystemAccount account)
        {
            await _accountRepository.UpdateAsync(account);
            await _accountRepository.SaveAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var account = await _accountRepository.GetAsync(a => a.Id == id);
            if (account == null)
                throw new Exception("Account not found");

            var hasNewsArticles = await _newsArticleRepository.GetAllAsync(na => na.CreatedById == id);
            if (hasNewsArticles.Any())
                throw new Exception("Cannot delete account with associated news articles");

            await _accountRepository.RemoveAsync(account);
            await _accountRepository.SaveAsync();
        }
    }
}
