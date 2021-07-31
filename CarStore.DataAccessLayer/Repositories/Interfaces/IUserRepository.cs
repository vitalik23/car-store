

using CarStore.DataAccessLayer.Entities;
using System.Threading.Tasks;

namespace CarStore.DataAccessLayer.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> UpdateAsync(User model);
    }
}
