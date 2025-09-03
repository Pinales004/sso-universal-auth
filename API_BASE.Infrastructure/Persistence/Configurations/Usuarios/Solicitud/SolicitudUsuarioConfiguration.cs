using API_BASE.Domain.Entities.Usuario.Solicitud;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Infrastructure.Persistence.Configurations.Usuarios.Solicitud
{
    public class SolicitudUsuarioConfiguration : IEntityTypeConfiguration<SolicitudUsuario>
    {
        public void Configure(EntityTypeBuilder<SolicitudUsuario> builder)
        {
            builder.ToTable("SolicitudesUsuario", "usuarios");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Tipo).IsRequired().HasMaxLength(40);
            builder.Property(s => s.Estado).IsRequired().HasMaxLength(20);
        }
    }
}