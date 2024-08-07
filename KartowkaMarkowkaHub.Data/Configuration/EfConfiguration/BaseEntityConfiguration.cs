using KartowkaMarkowkaHub.Core;
using KartowkaMarkowkaHub.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartowkaMarkowkaHub.Data.Configuration.EfConfiguration
{
    public class BaseEntityConfiguration : IEntityTypeConfiguration<BaseEntity>
    {
        public void Configure(EntityTypeBuilder<BaseEntity> builder)
        {
            // TPT TPC TPH 
            builder.UseTpcMappingStrategy();
            builder.HasKey(x => x.Id);
        }
    }
}
