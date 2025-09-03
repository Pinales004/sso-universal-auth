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
            builder.ToTable("UsuarioRoles", "seguridad");
            builder.HasKey(ur => ur.Id);

            builder.HasOne(ur => ur.Usuario)
                .WithMany(u => u.Roles)
                .HasForeignKey(ur => ur.UsuarioId);

            builder.HasOne(ur => ur.Rol)
                .WithMany(r => r.UsuarioRoles)
                .HasForeignKey(ur => ur.RolId);

            builder.HasOne(ur => ur.Organismo)
                .WithMany()
                .HasForeignKey(ur => ur.OrganismoId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
