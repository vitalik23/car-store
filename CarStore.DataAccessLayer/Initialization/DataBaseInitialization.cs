

using CarStore.DataAccessLayer.Entities;
using CarStore.Shared.Common.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace CarStore.DataAccessLayer.Initialization
{
    public static class DataBaseInitialization
    {
        public static async Task InitializeAsync(this IServiceCollection service)
        {
            var roleManager = service.BuildServiceProvider().GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = service.BuildServiceProvider().GetRequiredService<UserManager<User>>();

            string adminEmail = "admin@gmail.com";
            string password = "password";

            if (!await roleManager.RoleExistsAsync(Enum.UserRoles.Admin.ToString()))
            {
                var adminRole = new IdentityRole
                {
                    Name = Enum.UserRoles.Admin.ToString(),
                    NormalizedName = Enum.UserRoles.Admin.ToString().ToUpper()
                };
                await roleManager.CreateAsync(adminRole);
            }
            if (!await roleManager.RoleExistsAsync(Enum.UserRoles.Seller.ToString()))
            {
                var clientRole = new IdentityRole
                {
                    Name = Enum.UserRoles.Seller.ToString(),
                    NormalizedName = Enum.UserRoles.Seller.ToString().ToUpper()
                };
                await roleManager.CreateAsync(clientRole);
            }

            if (await userManager.FindByNameAsync(adminEmail) is null)
            {

                var admin = new User
                {
                    Email = adminEmail,
                    UserName = adminEmail,
                    EmailConfirmed = true,
                    FirstName = "Admin",
                    LastName = "Admin"
                };

                var resultCreate = await userManager.CreateAsync(admin, password);

                //if (!resultCreate.Succeeded)
                //{
                //    throw new ServerException(Constants.Errors.USER_NOT_REGISTERED);
                //}

                var resultAddTooRole = await userManager.AddToRoleAsync(admin, Enum.UserRoles.Admin.ToString());

                //if (!resultAddTooRole.Succeeded)
                //{
                //    throw new ServerException(Constants.Errors.USER_NOT_ADDED_TO_ROLE);
                //}

            }

        }
    }
}
