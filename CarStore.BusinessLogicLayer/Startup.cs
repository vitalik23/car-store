using CarStore.BusinessLogicLayer.Services;
using CarStore.BusinessLogicLayer.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CarStore.BusinessLogicLayer
{
    public static class Startup
    {
        public static void BusinessLogicInitializer(this IServiceCollection service, 
                                                    IConfiguration configuration)
        {
            DataAccessLayer.Startup.DataAccessInitializer(service, configuration);

            service.AddTransient<IFileService, FileService>();
        }  
    }
}
