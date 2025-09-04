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
        public string Nombre { get; set; } = string.Empty;
        public bool EsGlobal { get; set; } = false;
        public bool Activo { get; set; } = true;
        public string? Descripcion { get; set; }

        public ICollection<RolPermiso> RolPermisos { get; set; } = new List<RolPermiso>();
        public ICollection<UsuarioRol> UsuarioRoles { get; set; } = new List<UsuarioRol>();
    }
}
