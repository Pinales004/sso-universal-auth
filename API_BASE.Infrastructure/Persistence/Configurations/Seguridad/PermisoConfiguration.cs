using API_BASE.Domain.Entities.Mantenimiento;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Infrastructure.Persistence.Configurations.Seguridad
{
    public class PermisoConfiguration : IEntityTypeConfiguration<Permiso>
    {
        public void Configure(EntityTypeBuilder<Permiso> builder)
        {
            builder.ToTable("Permisos", "seguridad");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Codigo).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Nombre).IsRequired().HasMaxLength(100);

            builder.HasMany(p => p.UsuarioPermisos)
                   .WithOne(up => up.Permiso)
                   .HasForeignKey(up => up.PermisoId);

            builder.HasMany(p => p.RolPermisos)
                   .WithOne(rp => rp.Permiso)
                   .HasForeignKey(rp => rp.PermisoId);
        }
    }
}