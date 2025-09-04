using API_BASE.Domain.Base;
using API_BASE.Domain.Entities.Seguridad;
using API_BASE.Domain.Enums;
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
        public Guid? AplicacionId { get; set; } // Opcional: alcance por aplicación
        public Guid? NodoId { get; set; }       // Opcional: nodo funcional
        public bool Hereda { get; set; } = true;   // Para herencia funcional
                                                
        public Efecto Efecto { get; set; } 

        // Relaciones de navegación
        public Rol Rol { get; set; } = null!;
        public Permiso Permiso { get; set; } = null!;
        public Nodo? Nodo { get; set; }
        public API_BASE.Domain.Entities.Aplicacion.Aplicacion? Aplicacion { get; set; }


    }
}
