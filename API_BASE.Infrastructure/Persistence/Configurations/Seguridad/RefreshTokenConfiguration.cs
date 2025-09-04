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
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.ToTable("RefreshTokens", "seguridad");
            builder.HasKey(r => r.Id);

            // Relaciones
            builder.HasOne(r => r.Sesion)
                   .WithMany(s => s.RefreshTokens)
                   .HasForeignKey(r => r.SesionId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.Usuario)
                   .WithMany(u => u.RefreshTokens)
                   .HasForeignKey(r => r.UsuarioId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Propiedades
            builder.Property(r => r.TokenHash)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(r => r.UserAgent)
                   .HasMaxLength(200);

            builder.Property(r => r.Ip)
                   .HasMaxLength(50);

            builder.Property(r => r.ExpiraEn)
                   .IsRequired();
        }
    }
}
