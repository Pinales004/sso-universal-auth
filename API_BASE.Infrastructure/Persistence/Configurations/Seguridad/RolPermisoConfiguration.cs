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
    public class RolPermisoConfiguration : IEntityTypeConfiguration<RolPermiso>
    {
        public void Configure(EntityTypeBuilder<RolPermiso> builder)
        {
            builder.ToTable("RolPermisos", "seguridad");
            builder.HasKey(rp => rp.Id);
            builder.HasIndex(rp => new { rp.RolId, rp.PermisoId, rp.AplicacionId }).IsUnique();

            builder.HasOne(rp => rp.Rol)
                .WithMany(r => r.Permisos)
                .HasForeignKey(rp => rp.RolId);

            builder.HasOne(rp => rp.Permiso)
                .WithMany(p => p.Roles)
                .HasForeignKey(rp => rp.PermisoId);

            builder.HasOne(rp => rp.Aplicacion)
                .WithMany()
                .HasForeignKey(rp => rp.AplicacionId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}