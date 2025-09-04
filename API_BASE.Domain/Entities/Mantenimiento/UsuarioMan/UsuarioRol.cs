using API_BASE.Domain.Base;
using API_BASE.Domain.Entities.Seguridad;
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
        public Guid? OrganismoIdExt { get; set; }
        public Guid? NodoId { get; set; } // Nodo funcional si aplica
        public bool IncluirDescendientes { get; set; } = true;
        public DateTime? Desde { get; set; }
        public DateTime? Hasta { get; set; }

        // Relaciones
        public API_BASE.Domain.Entities.Usuario.Usuario Usuario { get; set; } = null!;
        public Rol Rol { get; set; } = null!;
        public API_BASE.Domain.Entities.Organismo.Organismo? Organismo { get; set; }
        public Nodo? Nodo { get; set; }
    }
}
