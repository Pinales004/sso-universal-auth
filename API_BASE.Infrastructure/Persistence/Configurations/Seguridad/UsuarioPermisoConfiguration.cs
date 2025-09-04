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
    public class UsuarioPermisoConfiguration : IEntityTypeConfiguration<UsuarioPermiso>
    {
            public void Configure(EntityTypeBuilder<UsuarioPermiso> builder)
            {
                builder.ToTable("UsuarioPermisos", "seguridad");
                builder.HasKey(up => up.Id);

                builder.HasOne(up => up.Usuario)
                       .WithMany(u => u.Permisos)
                       .HasForeignKey(up => up.UsuarioId);

                builder.HasOne(up => up.Permiso)
                       .WithMany(p => p.UsuarioPermisos)
                       .HasForeignKey(up => up.PermisoId);

                builder.HasOne(up => up.Nodo)
                       .WithMany()
                       .HasForeignKey(up => up.NodoId)
                       .IsRequired();

                builder.HasMany(up => up.Hijos)
                       .WithOne()
                       .HasForeignKey("ParentId");
            }
        }
}
