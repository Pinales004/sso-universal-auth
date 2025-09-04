using API_BASE.Domain.Entities.Usuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Infrastructure.Persistence.Configurations.Usuarios
{
        public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
        {
            public void Configure(EntityTypeBuilder<Usuario> builder)
            {
                builder.ToTable("Usuarios", "Usuarios");
                builder.HasKey(u => u.Id);

                builder.Property(u => u.Email)
                       .IsRequired()
                       .HasMaxLength(150);

                builder.Property(u => u.Username)
                       .HasMaxLength(500);

                builder.Property(u => u.Telefono)
                       .HasMaxLength(50);

                builder.Property(u => u.PasswordHash)
                       .IsRequired();

                builder.Property(u => u.PasswordSalt)
                       .IsRequired();

                builder.Property(u => u.MfaEnabled)
                       .HasDefaultValue(false);

                builder.HasMany(u => u.Roles)
                       .WithOne(ur => ur.Usuario)
                       .HasForeignKey(ur => ur.UsuarioId);

                builder.HasMany(u => u.Permisos)
                       .WithOne(up => up.Usuario)
                       .HasForeignKey(up => up.UsuarioId);

                builder.HasMany(u => u.Organizaciones)
                       .WithOne(o => o.Usuario)
                       .HasForeignKey(o => o.UsuarioId);
            }
        }
    }
