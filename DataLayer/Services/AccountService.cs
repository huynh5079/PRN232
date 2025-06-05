using DataLayer.Entities;
using DataLayer.Repositories;
using DataLayer.Utilities;

namespace DataLayer.Services
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

        private async Task<bool> IsEmailUnique(string email, string? excludeId = null)
        {
            var existingAccount = await _accountRepository.GetAsync(a => a.AccountEmail == email);
            return existingAccount == null || (existingAccount.Id == excludeId);
        }

        public async Task<IEnumerable<SystemAccount>> GetAllAsync()
        {
            return await _accountRepository.GetAllAsync();
        }

        public async Task<SystemAccount?> GetByIdAsync(string id)
        {
            return await _accountRepository.GetAsync(a => a.Id == id);
        }

        public async Task CreateAsync(SystemAccount account)
        {
            if (!await IsEmailUnique(account.AccountEmail))
            {
                throw new Exception("Account with this email already exists.");
            }
            await _accountRepository.CreateAsync(account);
            await _accountRepository.SaveAsync();
        }
        public async Task UpdateAsync(SystemAccount account, string? newPlainPassword = null)
        {
            var existingAccount = await _accountRepository.GetAsync(a => a.Id == account.Id);
            if (existingAccount == null)
            {
                throw new Exception("Account not found.");
            }

            if (existingAccount.AccountEmail != account.AccountEmail && !await IsEmailUnique(account.AccountEmail, account.Id))
            {
                throw new Exception("Account with this email already exists.");
            }

            existingAccount.AccountName = account.AccountName;
            existingAccount.AccountEmail = account.AccountEmail;
            existingAccount.AccountRole = account.AccountRole;
            existingAccount.UpdatedAt = DateTime.UtcNow;

            if (!string.IsNullOrEmpty(newPlainPassword))
            {
                existingAccount.AccountPassword = PasswordHasher.HashPassword(newPlainPassword);
            }

            await _accountRepository.UpdateAsync(existingAccount);
            await _accountRepository.SaveAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var account = await _accountRepository.GetAsync(a => a.Id == id);
            if (account == null)
                throw new Exception("Account not found");

            var hasNewsArticles = await _newsArticleRepository.GetAllAsync(na => na.CreatedById == id);
            if (hasNewsArticles.Any())
                throw new Exception("Cannot delete account with associated news articles.");

            await _accountRepository.RemoveAsync(account);
            await _accountRepository.SaveAsync();
        }
    }
}