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
    public class SesionConfiguration : IEntityTypeConfiguration<Sesion>
    {
        public void Configure(EntityTypeBuilder<Sesion> builder)
        {
            builder.ToTable("Sesiones", "seguridad");
            builder.HasKey(s => s.Id);

            builder.HasOne(s => s.Usuario)
                .WithMany()
                .HasForeignKey(s => s.UsuarioId);
        }
    }
}
