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
    public class NotificacionConfiguration : IEntityTypeConfiguration<Notificacion>
    {
        public void Configure(EntityTypeBuilder<Notificacion> builder)
        {
            builder.ToTable("Notificaciones", "notificaciones");
            builder.HasKey(n => n.Id);
            builder.Property(n => n.Titulo).IsRequired();
            builder.Property(n => n.Mensaje).IsRequired();
            builder.Property(n => n.Tipo).IsRequired().HasMaxLength(50);
        }
    }
}
