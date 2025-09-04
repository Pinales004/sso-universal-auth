using API_BASE.Domain.Entities.Organismo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Infrastructure.Persistence.Configurations.Organizacion
{
    public class OrganismoConfiguration : IEntityTypeConfiguration<Organismo>
    {
        public void Configure(EntityTypeBuilder<Organismo> builder)
        {
            builder.ToTable("Organismos", "seguridad");
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Nombre)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(o => o.Codigo)
                   .HasMaxLength(200)
                   .IsRequired(false);

            // Relaciones jerárquicas
            builder.HasOne(o => o.Padre)
                   .WithMany(o => o.Hijos)
                   .HasForeignKey(o => o.ParentId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Relación con UsuarioOrganizaciones
            builder.HasMany(o => o.UsuarioOrganizaciones)
                   .WithOne(uo => uo.Organismo)
                   .HasForeignKey(uo => uo.OrganismoId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
