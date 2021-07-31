using CarStore.BusinessLogicLayer.Providers;
using CarStore.BusinessLogicLayer.Services;
using CarStore.BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace CarStore.BusinessLogicLayer
{
    public static class Startup
    {
        public static void BusinessLogicInitializer(this IServiceCollection service, 
                                                    IConfiguration configuration)
        {
            DataAccessLayer.Startup.DataAccessInitializer(service, configuration);

            service.AddTransient<IFileService, FileService>();
            service.AddTransient<IAccountService, AccountService>();

            service.AddTransient<JwtProvider>();

            service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                //.AddCookie(IdentityConstants.ApplicationScheme)
                //.AddCookie(IdentityConstants.ExternalScheme)
                //.AddCookie(IdentityConstants.TwoFactorUserIdScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ClockSkew = TimeSpan.FromMinutes(0),
                        ValidateIssuer = true,
                        ValidIssuer = configuration["jwtConfig:Issuer"],
                        ValidateAudience = true,
                        ValidAudience = configuration["jwtConfig:Audience"],
                        ValidateLifetime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["jwtConfig:SecretKey"])),
                        ValidateIssuerSigningKey = true,
                    };
                });
        }  
    }
}
