using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        //new
        IQueryable<T> GetAllAsQueryable(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IQueryable<T>>? includes = null);

        //old
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IQueryable<T>>? includes = null);
        Task<T> GetAsync(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IQueryable<T>>? includes = null);
        Task CreateAsync(T entity);
        Task RemoveAsync(T entity);
        Task UpdateAsync(T entity);
        Task SaveAsync();
    }

    public interface IPaginationRepository<T> where T : class
    {
        Task<PaginationResult<T>> GetPaginatedAsync(int pageNumber = 1, int pageSize = 10, Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IQueryable<T>>? includes = null);
    }

    public class PaginationResult<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
