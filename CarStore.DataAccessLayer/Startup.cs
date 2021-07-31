using CarStore.DataAccessLayer.AppContext;
using CarStore.DataAccessLayer.Entities;
using CarStore.DataAccessLayer.Initialization;
using CarStore.DataAccessLayer.Repositories;
using CarStore.DataAccessLayer.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace CarStore.DataAccessLayer
{
    public static class Startup
    {
        public static void DataAccessInitializer(this IServiceCollection service, 
                                                 IConfiguration configuration)
        {


            service.AddDbContext<ApplicationContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            service.AddIdentityCore<User>(opts => 
            {
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;

                opts.User.RequireUniqueEmail = true;
                opts.User.AllowedUserNameCharacters = ".@abcdefghijklmnopqrstuvwxyz1234567890";
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationContext>();

            //service.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            service.AddTransient<IUserRepository, UserRepository>();

            Task.Run(() => DataBaseInitialization.InitializeAsync(service));

        }
    }
}
