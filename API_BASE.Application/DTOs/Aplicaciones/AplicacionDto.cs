using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.DTOs.Aplicaciones
{
    public class AplicacionDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public string? Descripcion { get; set; }
        public string? RedirectUri { get; set; }
        public string? ClientId { get; set; }
        public string? ClientSecret { get; set; }
        public bool Activo { get; set; }
    }
}
