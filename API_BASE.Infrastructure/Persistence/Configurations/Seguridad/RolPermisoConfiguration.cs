using API_BASE.Domain.Entities.Mantenimiento;
using API_BASE.Domain.Enums;
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

            builder.HasOne(rp => rp.Rol)
                   .WithMany(r => r.RolPermisos)
                   .HasForeignKey(rp => rp.RolId);

            builder.HasOne(rp => rp.Permiso)
                   .WithMany(p => p.RolPermisos)
                   .HasForeignKey(rp => rp.PermisoId);

            builder.HasOne(rp => rp.Nodo)
                   .WithMany(n => n.RolPermisos)
                   .HasForeignKey(rp => rp.NodoId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(rp => rp.Aplicacion)
                   .WithMany()
                   .HasForeignKey(rp => rp.AplicacionId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.Property(rp => rp.Hereda)
                   .HasDefaultValue(true);

            builder.Property(rp => rp.Efecto)
                .HasDefaultValue(Efecto.ALLOW);
        }
    }
}