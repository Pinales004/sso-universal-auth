using API_BASE.Domain.Entities.Notificaciones;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Infrastructure.Persistence.Configurations.Notificaciones
{
    public class NotificacionUsuarioConfiguration : IEntityTypeConfiguration<NotificacionUsuario>
    {
        public void Configure(EntityTypeBuilder<NotificacionUsuario> builder)
        {
            builder.ToTable("NotificacionesUsuario", "notificaciones");
            builder.HasKey(nu => nu.Id);

            builder.HasOne(nu => nu.Notificacion)
                .WithMany(n => n.Destinatarios)
                .HasForeignKey(nu => nu.NotificacionId);

            builder.HasOne(nu => nu.Usuario)
                .WithMany()
                .HasForeignKey(nu => nu.UsuarioId);
        }
    }
}
