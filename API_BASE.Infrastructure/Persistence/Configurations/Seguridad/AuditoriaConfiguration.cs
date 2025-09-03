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
    public class AuditoriaConfiguration : IEntityTypeConfiguration<Auditoria>
    {
        public void Configure(EntityTypeBuilder<Auditoria> builder)
        {
            builder.ToTable("Auditorias", "seguridad");
            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.Actor)
                .WithMany()
                .HasForeignKey(a => a.ActorId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
