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
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(ur => new {ur.UserId,ur.RoleId});

            builder.HasOne(x => x.Role)
                .WithMany(u => u.Users)
                .HasForeignKey(f => f.RoleId);

            builder.HasOne(x => x.User)
                .WithMany(u => u.Roles)
                .HasForeignKey(f => f.UserId);
        }
    }
}
