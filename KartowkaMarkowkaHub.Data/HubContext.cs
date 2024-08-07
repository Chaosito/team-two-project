using Microsoft.EntityFrameworkCore;
using KartowkaMarkowkaHub.Core.Domain;
using KartowkaMarkowkaHub.Data.Configuration.EfConfiguration;
using KartowkaMarkowkaHub.Data.Configuration;
using Microsoft.Extensions.Logging;

namespace KartowkaMarkowkaHub.Data
{
    public class HubContext: DbContext
    {
        public DbSet<Client> Clients { get; set; }

        //public DbSet<Basket> Baskets { get; set; }

        public DbSet<Farmer> Farmers { get; set; }

        //public DbSet<Order> Orders { get; set; }

        //public DbSet<OrderItem> Items { get; set; }

        //public DbSet<OrderStatus> OrderStatus { get; set; }

        //public DbSet<Product> Products { get; set; }

        //public DbSet<Storage> Storages { get; set; }

        public HubContext(DbContextOptions<HubContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BaseEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new FarmerConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var dbName = DbConfiguration.DbName;
            //options.UseLazyLoadingProxies();
            options.UseSqlite($"Data Source={dbName}");
            options.EnableSensitiveDataLogging().LogTo(Console.WriteLine, LogLevel.Information);
        }
    }
}
