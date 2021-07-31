

using CarStore.BusinessLogicLayer.Models.Account;
using System.Threading.Tasks;

namespace CarStore.BusinessLogicLayer.Services.Interfaces
{
    public interface IAccountService
    {
        public Task<TokenResponseModel> LogInAsync(LoginModel model);
    }
}
