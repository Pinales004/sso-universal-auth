using API_BASE.Domain.Base;
using API_BASE.Domain.Entities.Seguridad;
using API_BASE.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Domain.Entities.Mantenimiento.UsuarioMan
{
    public class UsuarioPermiso : AuditableEntity
    {
        public Guid UsuarioId { get; set; }
        public Guid PermisoId { get; set; }
        public string? Comentario { get; set; }
        public DateTime? Desde { get; set; }
        public DateTime? Hasta { get; set; }

        // Propiedades necesarias para PolicyEvaluator
        public Guid NodoId { get; set; }                 // Nodo funcional al que aplica el permiso
        public Efecto Efecto { get; set; }             // ALLOW / DENY

        // Para herencia funcional si aplicas
        public ICollection<UsuarioPermiso> Hijos { get; set; } = new List<UsuarioPermiso>();

        // Relaciones de navegación
        public API_BASE.Domain.Entities.Usuario.Usuario Usuario { get; set; } = null!;
        public Permiso Permiso { get; set; } = null!;
        public Nodo Nodo { get; set; } = null!;
    }
}

