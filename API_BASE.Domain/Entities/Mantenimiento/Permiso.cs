using API_BASE.Domain.Base;
using API_BASE.Domain.Entities.Mantenimiento.UsuarioMan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Domain.Entities.Mantenimiento
{
    public class Permiso : AuditableEntity
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public ICollection<RolPermiso> Roles { get; set; } = new List<RolPermiso>();
        public ICollection<UsuarioPermiso> UsuarioPermisos { get; set; } = new List<UsuarioPermiso>();
    }
}
