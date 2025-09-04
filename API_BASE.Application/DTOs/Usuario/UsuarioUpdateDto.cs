using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.DTOs.Usuario
{
    public class UsuarioUpdateDto
    {
        public string? Username { get; set; }
        public string? Telefono { get; set; }
        public int Estado { get; set; }
        public bool EsAdminGlobal { get; set; }
    }
}
