using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.DTOs.Usuario
{
    public class UsuarioCreateDto
    {
        public string Email { get; set; } = null!;
        public string? Username { get; set; }
        public string? Telefono { get; set; }
        public int Estado { get; set; }
        public string Password { get; set; } = null!;
        public bool EsAdminGlobal { get; set; } = false;
    }
}
