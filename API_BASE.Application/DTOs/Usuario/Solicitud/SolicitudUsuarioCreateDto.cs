using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.DTOs.Usuario.Solicitud
{
    public class SolicitudUsuarioCreateDto
    {
        public int UsuarioId { get; set; }
        public int Tipo { get; set; }
    }
}
