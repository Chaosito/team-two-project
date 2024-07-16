using Microsoft.EntityFrameworkCore;
using KartowkaMarkowkaHub.Core.Domain;
using KartowkaMarkowkaHub.Data.Configuration.EfConfiguration;

namespace KartowkaMarkowkaHub.Data
{
    public class HubContext: DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public DbSet<Basket> Baskets { get; set; }

        public DbSet<Farmer> Farmers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> Items { get; set; }

        public DbSet<OrderStatus> OrderStatus { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Storage> Storages { get; set; }

        public HubContext(DbContextOptions<HubContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ClientConfiguration());
        }
    }
}
