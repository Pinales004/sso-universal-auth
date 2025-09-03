using API_BASE.Domain.Base;
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

        public Usuario.Usuario Usuario { get; set; }
        public Permiso permiso { get; set; }
    }
}

