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
    public class MfaRecoveryCodeConfiguration : IEntityTypeConfiguration<MfaRecoveryCode>
    {
        public void Configure(EntityTypeBuilder<MfaRecoveryCode> builder)
        {
            builder.ToTable("MfaRecoveryCodes", "usuarios");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.CodeHash).IsRequired();
        }
    }
}
