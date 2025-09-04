using API_BASE.Domain.Entities.Mantenimiento.UsuarioMan;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Infrastructure.Persistence.Configurations.Seguridad
{

    public class UsuarioRolConfiguration : IEntityTypeConfiguration<UsuarioRol>
    {
        public void Configure(EntityTypeBuilder<UsuarioRol> builder)
    {
        // Tabla y esquema
        builder.ToTable("UsuarioRoles", "seguridad");

        builder.HasKey(ur => ur.Id);

        // Relaciones
        builder.HasOne(ur => ur.Usuario)
               .WithMany(u => u.Roles)
               .HasForeignKey(ur => ur.UsuarioId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ur => ur.Rol)
               .WithMany(r => r.UsuarioRoles)
               .HasForeignKey(ur => ur.RolId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ur => ur.Organismo)
               .WithMany()
               .HasForeignKey(ur => ur.OrganismoIdExt)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(ur => ur.Nodo)
               .WithMany()
               .HasForeignKey(ur => ur.NodoId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.SetNull);

        // Propiedades
        builder.Property(ur => ur.IncluirDescendientes)
               .HasDefaultValue(true);

        builder.Property(ur => ur.Desde)
               .IsRequired(false);

        builder.Property(ur => ur.Hasta)
               .IsRequired(false);

        // Índices opcionales
        builder.HasIndex(ur => new { ur.UsuarioId, ur.RolId, ur.OrganismoIdExt, ur.NodoId })
               .IsUnique(false);
    }
}


}
