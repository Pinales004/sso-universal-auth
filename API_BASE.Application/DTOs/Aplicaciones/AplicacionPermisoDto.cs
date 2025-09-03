using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.DTOs.Aplicaciones
{
    public class AplicacionPermisoDto
    {
        public Guid Id { get; set; }
        public Guid AplicacionId { get; set; }
        public Guid PermisoId { get; set; }
    }
}
