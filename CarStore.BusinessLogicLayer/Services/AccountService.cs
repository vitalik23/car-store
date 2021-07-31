using CarStore.BusinessLogicLayer.Models.Account;
using CarStore.BusinessLogicLayer.Providers;
using CarStore.BusinessLogicLayer.Services.Interfaces;
using CarStore.DataAccessLayer.Entities;
using CarStore.DataAccessLayer.Repositories;
using CarStore.DataAccessLayer.Repositories.Interfaces;
using CarStore.Shared.Common.Exceptions;
using Microsoft.AspNetCore.Identity;
using System.Net;
using System.Threading.Tasks;

namespace CarStore.BusinessLogicLayer.Services
{
    public class AccountService : IAccountService
    {
        private UserManager<User> _userManager;
        private JwtProvider _jwtProvider;
        private IUserRepository _userRepository;

        public AccountService(UserManager<User> userManager, JwtProvider jwtProvider,
            IUserRepository userRepository)
        {
            _userManager = userManager;
            _jwtProvider = jwtProvider;
            _userRepository = userRepository;
        }

        public async Task<TokenResponseModel> LogInAsync(LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null)
            {
                throw new ServerException("User not found", HttpStatusCode.NotFound);
            }

            if (!await _userManager.CheckPasswordAsync(user, model.Password))
            {
                throw new ServerException("Incorrect password", HttpStatusCode.BadRequest);
            }

            var claims = await _jwtProvider.GetUserClaimsAsync(user.Email);
            string accessToken = _jwtProvider.GenerateAccessToken(claims);
            string refreshToken = _jwtProvider.GenerateRefreshToken();

            user.RefreshToken = refreshToken;

            await _userRepository.UpdateAsync(user);

            var tokens = new TokenResponseModel
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };

            return tokens;
        }
    }
}
