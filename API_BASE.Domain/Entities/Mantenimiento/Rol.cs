using API_BASE.Domain.Base;
using API_BASE.Domain.Entities.Mantenimiento.UsuarioMan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Domain.Entities.Mantenimiento
{
    public class Rol : AuditableEntity
    {
        public string Nombre { get; set; }
        public bool EsGlobal { get; set; }
        public string? Descripcion { get; set; }
        public bool Activo { get; set; } = true;
        public ICollection<RolPermiso> Permisos { get; set; } = new List<RolPermiso>();
        public ICollection<UsuarioRol> UsuarioRoles { get; set; } = new List<UsuarioRol>(); 
    }
}
