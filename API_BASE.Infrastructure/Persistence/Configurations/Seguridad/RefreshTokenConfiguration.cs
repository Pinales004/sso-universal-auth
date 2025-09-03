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

            builder.HasOne(r => r.Sesion)
                .WithMany(s => s.RefreshTokens)
                .HasForeignKey(r => r.SesionId);
        }
    }
}
