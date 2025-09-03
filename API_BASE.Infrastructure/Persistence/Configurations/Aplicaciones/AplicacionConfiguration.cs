using API_BASE.Domain.Entities.Aplicacion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Infrastructure.Persistence.Configurations.Aplicaciones
{
    public class AplicacionConfiguration : IEntityTypeConfiguration<Aplicacion>
    {
        public void Configure(EntityTypeBuilder<Aplicacion> builder)
        {
            builder.ToTable("Aplicaciones", "aplicaciones");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Nombre).IsRequired().HasMaxLength(200);
            builder.Property(a => a.Codigo).IsRequired().HasMaxLength(100);
            builder.HasIndex(a => a.Codigo).IsUnique();
        }
    }
}
