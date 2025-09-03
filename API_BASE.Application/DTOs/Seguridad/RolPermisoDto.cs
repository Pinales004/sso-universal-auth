using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.DTOs.Seguridad
{
    public class RolPermisoDto
    {
        public Guid Id { get; set; }
        public Guid RolId { get; set; }
        public Guid PermisoId { get; set; }
        public Guid? AplicacionId { get; set; }
        public bool Hereda { get; set; }
        public bool Denegado { get; set; }
    }
}
