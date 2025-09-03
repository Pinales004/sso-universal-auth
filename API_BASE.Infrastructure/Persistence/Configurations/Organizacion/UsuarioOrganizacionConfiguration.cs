using API_BASE.Domain.Entities.Usuario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Infrastructure.Persistence.Configurations.Organizacion
{
    public class UsuarioOrganizacionConfiguration : IEntityTypeConfiguration<UsuarioOrganizacion>
    {
        public void Configure(EntityTypeBuilder<UsuarioOrganizacion> builder)
        {
            builder.ToTable("UsuarioOrganizaciones", "organizacion");
            builder.HasKey(uo => uo.Id);

            builder.HasOne(uo => uo.Usuario)
                .WithMany(u => u.Organizaciones)
                .HasForeignKey(uo => uo.UsuarioId);

            builder.HasOne(uo => uo.Organismo)
                .WithMany(o => o.UsuarioOrganizaciones)
                .HasForeignKey(uo => uo.OrganismoId);
        }
    }
}
