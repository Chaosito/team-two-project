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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //builder.Navigation<Client>(c => c.ClientInfo).IsRequired(false);

            //builder.Navigation<Farmer>(c => c.FarmerInfo).IsRequired(false);
            //
            //builder.HasOne(x => x.FarmerInfo)
            //    .WithOne(y => y.User)
            //    .HasForeignKey<Farmer>(f => f.FarmerId);
            //
            //builder.HasOne(x => x.ClientInfo)
            //    .WithOne(y => y.User)
            //    .HasForeignKey<Client>(f => f.ClientId);
        }
    }
}
