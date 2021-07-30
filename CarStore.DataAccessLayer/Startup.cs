using CarStore.DataAccessLayer.AppContext;
using CarStore.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarStore.DataAccessLayer
{
    public static class Startup
    {
        public static void DataAccessInitializer(this IServiceCollection service, 
                                                 IConfiguration configuration)
        {
            service.AddDbContext<ApplicationContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            service.AddIdentityCore<User>()
                .AddEntityFrameworkStores<ApplicationContext>();
        }
    }
}
