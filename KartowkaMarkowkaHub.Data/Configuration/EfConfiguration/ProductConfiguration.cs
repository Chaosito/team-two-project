using KartowkaMarkowkaHub.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KartowkaMarkowkaHub.Data.Configuration.EfConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(x => x.User)
                .WithMany(y => y.Products)
                .HasForeignKey(f => f.UserId);
        }
    }
}