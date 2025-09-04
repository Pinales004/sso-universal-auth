using API_BASE.Domain.Base;
using API_BASE.Domain.Entities.Mantenimiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Domain.Entities.Seguridad
{
    public class Nodo : AuditableEntity
    {
        public Guid? ParentId { get; set; }
        public string Tipo { get; set; } = string.Empty; // "Modulo", "Submodulo", "Feature"
        public string Codigo { get; set; } = string.Empty; // Ej: "EDU/Tramites/Evidencias"
        public string Nombre { get; set; } = string.Empty;
        public int? Orden { get; set; }
        public bool Activo { get; set; } = true;

        // Relación de jerarquía
        public Nodo? Padre { get; set; }
        public ICollection<Nodo> Hijos { get; set; } = new List<Nodo>();

        // Relación con permisos de roles
        public ICollection<RolPermiso> RolPermisos { get; set; } = new List<RolPermiso>();
    }
}

