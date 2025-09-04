using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.DTOs.Dashboard
{
    public class UsuariosPorEstadoDto
    {
        public int Activos { get; set; }
        public int Suspendidos { get; set; }
        public int Invitados { get; set; }

        public int TotalUsuarios { get; set; }
        public int Inactivos { get; set; }
    }
}
