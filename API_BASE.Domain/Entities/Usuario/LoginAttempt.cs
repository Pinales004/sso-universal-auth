using API_BASE.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Domain.Entities.Usuario
{
    //Propósito: Registrar todos los intentos de acceso (fallidos y exitosos).
    public class LoginAttempt : AuditableEntity
    {
        public Guid UsuarioId { get; set; }
        public DateTime FechaIntento { get; set; }
        public bool Exitoso { get; set; }
        public string? Ip { get; set; }
        public string? UserAgent { get; set; }

        public Usuario Usuario { get; set; }
    }
}

