using KartowkaMarkowkaHub.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartowkaMarkowkaHub.Data.Configuration.EfConfiguration
{
    public class FarmerConfiguration : IEntityTypeConfiguration<Farmer>
    {
        public void Configure(EntityTypeBuilder<Farmer> builder)
        {
            //builder.HasMany(x => x.Products)
            //    .WithOne(x => x.Farmer);
            //
            //builder.HasOne(x => x.User)
            //    .WithOne(y => y.FarmerInfo)
            //    .HasForeignKey<Farmer>(f => f.UserId);
        }
    }
}