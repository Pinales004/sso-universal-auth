using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.DTOs.Seguridad
{
    public class RolDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public bool EsGlobal { get; set; }
        public string? Descripcion { get; set; }
        public bool Activo { get; set; }
    }
}
