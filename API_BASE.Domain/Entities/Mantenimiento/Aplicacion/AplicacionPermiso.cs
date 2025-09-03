using API_BASE.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Domain.Entities.Mantenimiento.Aplicacion
{
    public class AplicacionPermiso : AuditableEntity
    {
        public Guid AplicacionId { get; set; }
        public Guid PermisoId { get; set; }

        public API_BASE.Domain.Entities.Aplicacion.Aplicacion Aplicacion { get; set; }
        public Permiso Permiso { get; set; }
    }
}
