using API_BASE.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Domain.Entities.Mantenimiento.UsuarioMan
{
    public class UsuarioRol : AuditableEntity
    {
        public Guid UsuarioId { get; set; }
        public Guid RolId { get; set; }
        public Guid? OrganismoId { get; set; }
        public DateTime? Desde { get; set; }
        public DateTime? Hasta { get; set; }
        // Relaciones
        public Usuario.Usuario Usuario { get; set; }
        public Rol Rol { get; set; }
        public Organismo.Organismo? Organismo { get; set; }
    }
}
