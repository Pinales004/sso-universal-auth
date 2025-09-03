using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.DTOs.Seguridad
{
    public class UsuarioPermisoDto
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid PermisoId { get; set; }
        public string? Comentario { get; set; }
        public DateTime? Desde { get; set; }
        public DateTime? Hasta { get; set; }
    }
}
