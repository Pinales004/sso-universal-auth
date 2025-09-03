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
        public string Tipo { get; set; }           // "Modulo", "Submodulo", "Feature"
        public string Codigo { get; set; }         // Ej: "EDU/Tramites/Evidencias"
        public string Nombre { get; set; }
        public int? Orden { get; set; }
        public bool Activo { get; set; } = true;

        public Nodo? Padre { get; set; }
        public ICollection<Nodo> Hijos { get; set; } = new List<Nodo>();
        public ICollection<RolPermiso> RolPermisos { get; set; } = new List<RolPermiso>();
    }
}

