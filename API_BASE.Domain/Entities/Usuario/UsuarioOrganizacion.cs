using API_BASE.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Domain.Entities.Usuario
{
    public class UsuarioOrganizacion : AuditableEntity
    {
        public Guid UsuarioId { get; set; }
        public Guid OrganismoId { get; set; }
        public bool EsPrincipal { get; set; }
        public DateTime? Desde { get; set; }
        public DateTime? Hasta { get; set; }

        // Relaciones de navegación
        public Usuario Usuario { get; set; }
        public API_BASE.Domain.Entities.Organismo.Organismo Organismo { get; set; }
    }
}
