using DataLayer.DTOs;
using DataLayer.Entities;
using BusinessLayer.Repositories;
using DataLayer.Utilities;

namespace BusinessLayer.Services
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
        public async Task UpdateAsync(string id, UpdateAccountDto accountDto)
        {
            var existingAccount = await _accountRepository.GetAsync(a => a.Id == id);
            if (existingAccount == null)
            {
                throw new Exception("Account not found.");
            }

            if (accountDto.AccountName != null)
            {
                existingAccount.AccountName = accountDto.AccountName;
            }

            if (accountDto.AccountRole.HasValue) 
            {
                existingAccount.AccountRole = accountDto.AccountRole.Value;
            }

            if (!string.IsNullOrEmpty(accountDto.NewPassword))
            {
                existingAccount.AccountPassword = PasswordHasher.HashPassword(accountDto.NewPassword);
            }

            existingAccount.UpdatedAt = DateTime.UtcNow;

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