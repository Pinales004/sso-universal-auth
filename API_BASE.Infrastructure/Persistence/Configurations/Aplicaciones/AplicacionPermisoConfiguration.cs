using API_BASE.Domain.Entities.Mantenimiento.Aplicacion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Infrastructure.Persistence.Configurations.Aplicaciones
{
    public class AplicacionPermisoConfiguration : IEntityTypeConfiguration<AplicacionPermiso>
    {
        public void Configure(EntityTypeBuilder<AplicacionPermiso> builder)
        {
            builder.ToTable("AplicacionPermisos", "aplicaciones");
            builder.HasKey(ap => ap.Id);

            builder.HasOne(ap => ap.Aplicacion)
                .WithMany(a => a.Permisos)
                .HasForeignKey(ap => ap.AplicacionId);

            builder.HasOne(ap => ap.Permiso)
                .WithMany()
                .HasForeignKey(ap => ap.PermisoId);
        }
    }
}
