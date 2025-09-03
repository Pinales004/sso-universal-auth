using API_BASE.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Domain.Entities.Mantenimiento
{
    public class RolPermiso : AuditableEntity
    {
        public Guid RolId { get; set; }
        public Guid PermisoId { get; set; }
        public Guid? AplicacionId { get; set; }        // Opcional: alcance por aplicación
        public Guid? NodoId { get; set; }              // Opcional: si implementas árbol funcional/nodos

        public bool Hereda { get; set; } = true;       // Para soportar herencia funcional si la implementas
        public bool Denegado { get; set; } = false;    // Para lógica DENY/ALLOW

        // Relaciones de navegación
        public Rol Rol { get; set; }
        public Permiso Permiso { get; set; }
        public API_BASE.Domain.Entities.Aplicacion.Aplicacion? Aplicacion { get; set; }
        // Nodo? Nodo; // Si usas árbol funcional/nodos, relación opcional


    }
}
