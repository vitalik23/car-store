

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarStore.DataAccessLayer.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        public Task<int> UpdateAsync(T item);
        public Task<int> CreateAsync(T item);
        public Task DeleteAsync(T item);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(Guid id);
        public Task AddRangeAsync(IEnumerable<T> item);
    }
}
