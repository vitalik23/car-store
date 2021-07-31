using CarStore.DataAccessLayer.AppContext;
using CarStore.DataAccessLayer.Entities;
using CarStore.DataAccessLayer.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CarStore.DataAccessLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApplicationContext _context;
        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<User> UpdateAsync(User model)
        {
            SqlParameter refreshToken = new SqlParameter("@refreshToken", model.RefreshToken);
            SqlParameter idUser = new SqlParameter("@idUser", model.Id);

            var result = (await _context.Users.FromSqlRaw("UpdateUser @refreshToken, @idUser", refreshToken, idUser).ToListAsync())
                .FirstOrDefault();

            return result;
        }
    }
}