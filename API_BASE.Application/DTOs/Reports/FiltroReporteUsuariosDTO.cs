using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.DTOs.Reports
{
    public class FiltroReporteUsuariosDTO
    {
        public string? Estado { get; set; }
        public DateTime? Desde { get; set; }
        public DateTime? Hasta { get; set; }
        public Guid? OrganismoId { get; set; }
        // Otros filtros relevantes
    }
}
