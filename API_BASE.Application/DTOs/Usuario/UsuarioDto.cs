using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.DTOs.Usuario
{
    public class UsuarioDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string? Username { get; set; }
        public string? Telefono { get; set; }
        public bool EsAdminGlobal { get; set; }
        public string Estado { get; set; }
    }
}
