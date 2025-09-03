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
    public class NodoConfiguration : IEntityTypeConfiguration<Nodo>
    {
        public void Configure(EntityTypeBuilder<Nodo> builder)
        {
            builder.ToTable("Nodos", "seguridad");
            builder.HasKey(n => n.Id);

            builder.HasOne(n => n.Padre)
                .WithMany(n => n.Hijos)
                .HasForeignKey(n => n.ParentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
