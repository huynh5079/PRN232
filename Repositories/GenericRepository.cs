using DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>, IPaginationRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        //New
        public IQueryable<T> GetAllAsQueryable(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IQueryable<T>>? includes = null)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includes != null)
            {
                query = includes(query);
            }
            return query; // Trả về IQueryable trực tiếp, không thực thi query
        }

        //Old
        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IQueryable<T>>? includes = null)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
                query = query.Where(filter);
            if (includes != null)
                query = includes(query);
            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IQueryable<T>>? includes = null)
        {
            IQueryable<T> query = _dbSet;
            if (includes != null)
                query = includes(query);
            return await query.FirstOrDefaultAsync(filter);
        }

        public async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task RemoveAsync(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<PaginationResult<T>> GetPaginatedAsync(int pageNumber = 1, int pageSize = 10, Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IQueryable<T>>? includes = null)
        {
            IQueryable<T> query = _dbSet;
            if (filter != null)
                query = query.Where(filter);
            if (includes != null)
                query = includes(query);

            var totalCount = await query.CountAsync();
            var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PaginationResult<T>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
    }
}
