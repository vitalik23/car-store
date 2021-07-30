

using CarStore.DataAccessLayer.AppContext;
using CarStore.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarStore.DataAccessLayer.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {

        protected ApplicationContext _context;
        protected DbSet<T> _dbSet;

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public Task AddRangeAsync(IEnumerable<T> item)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateAsync(T item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(T item)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public Task<T> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(T item)
        {
            throw new NotImplementedException();
        }
    }
}
