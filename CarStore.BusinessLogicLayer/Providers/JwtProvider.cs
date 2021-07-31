using CarStore.DataAccessLayer.Entities;
using CarStore.Shared.Common.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CarStore.BusinessLogicLayer.Providers
{
    public class JwtProvider
    {
        private IOptions<JwtConnectionOptions> _connectionOptions;
        private UserManager<User> _userManager;
        public JwtProvider(IOptions<JwtConnectionOptions> connectionOptions,
                          UserManager<User> userManager)
        {
            _userManager = userManager;
            _connectionOptions = connectionOptions;
        }

        public async Task<IEnumerable<Claim>> GetUserClaimsAsync(string email)
        {

            var user = await _userManager.FindByEmailAsync(email);
            var userRoles = await _userManager.GetRolesAsync(user);

            List<Claim> claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName)

            };

            claims.AddRange(userRoles.Select(item => new Claim(ClaimsIdentity.DefaultRoleClaimType, item)));

            new ClaimsIdentity(claims,
                "Token",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            return claims;
        }

        public string GenerateAccessToken(IEnumerable<Claim> claims)
        {

            var token = new JwtSecurityToken(
               issuer: _connectionOptions.Value.Issuer,
               audience: _connectionOptions.Value.Audience,
               claims: claims,
               notBefore: DateTime.Now,
               expires: DateTime.Now.AddMinutes(_connectionOptions.Value.Lifetime),
               signingCredentials: new SigningCredentials(GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
            );
            string accessToken = new JwtSecurityTokenHandler().WriteToken(token);

            return accessToken;
        }

        public string GenerateRefreshToken()
        {
            byte[] randomNumber = new byte[_connectionOptions.Value.LengthRefreshToken];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            var symetricKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_connectionOptions.Value.SecretKey));
            return symetricKey;
        }

        public ClaimsPrincipal ValidateToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = GetSymmetricSecurityKey(),
                ValidateLifetime = false
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            ClaimsPrincipal principal;
            try
            {
                principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            }
            catch
            {
                throw new Exception("Please input correct data");
            }

            return principal;
        }
    }
}
