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
            builder.ToTable("Usuarios", "usuarios");
            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.Email).IsRequired().HasMaxLength(200);
            builder.Property(u => u.Username).HasMaxLength(100);
            builder.Property(u => u.Telefono).HasMaxLength(30);

            builder.HasMany(u => u.PasswordHistories)
                .WithOne(ph => ph.Usuario)
                .HasForeignKey(ph => ph.UsuarioId);

            builder.HasMany(u => u.LoginAttempts)
                .WithOne(la => la.Usuario)
                .HasForeignKey(la => la.UsuarioId);
        }
    }
}
