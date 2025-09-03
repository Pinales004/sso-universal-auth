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
    public class PasswordResetRequestConfiguration : IEntityTypeConfiguration<PasswordResetRequest>
    {
        public void Configure(EntityTypeBuilder<PasswordResetRequest> builder)
        {
            builder.ToTable("PasswordResetRequests", "usuarios");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.TokenHash).IsRequired();
        }
    }
}
