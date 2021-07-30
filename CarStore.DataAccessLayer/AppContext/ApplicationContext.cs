using CarStore.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarStore.DataAccessLayer.AppContext
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<CarPhoto> CarPhotos { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<DataOfTransport> DataOfTransports { get; set; }
        public DbSet<KindTransport> KindTransports { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}
