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
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            //builder.HasMany(e => e.Orders)
            //    .WithOne(c => c.Client);

            //builder.HasOne(x => x.User)
            //    .WithOne(y => y.ClientInfo)
            //    .HasForeignKey<Client>(x => x.UserId);
        }
    }
}
