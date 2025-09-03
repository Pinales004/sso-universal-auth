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
    public class MfaTotpConfiguration : IEntityTypeConfiguration<MfaTotp>
    {
        public void Configure(EntityTypeBuilder<MfaTotp> builder)
        {
            builder.ToTable("MfaTotps", "usuarios");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Secret).IsRequired();
        }
    }
}
