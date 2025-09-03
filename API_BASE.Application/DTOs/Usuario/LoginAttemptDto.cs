using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.DTOs.Usuario
{
    public class LoginAttemptDto
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public DateTime FechaIntento { get; set; }
        public bool Exitoso { get; set; }
        public string? Ip { get; set; }
        public string? UserAgent { get; set; }
    }
}
