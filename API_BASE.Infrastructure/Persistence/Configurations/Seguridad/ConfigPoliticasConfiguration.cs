using API_BASE.Domain.Entities.Seguridad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Infrastructure.Persistence.Configurations.Seguridad
{
    public class ConfigPoliticasConfiguration : IEntityTypeConfiguration<ConfigPoliticas>
    {
        public void Configure(EntityTypeBuilder<ConfigPoliticas> builder)
        {
            builder.ToTable("ConfigPoliticas", "seguridad");
            builder.HasKey(c => c.Id);

            builder.HasIndex(c => c.Version).IsUnique();
        }
    }
}
