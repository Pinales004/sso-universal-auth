using API_BASE.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Domain.Entities.Seguridad
{
    public class RefreshToken : AuditableEntity
    {
        public Guid UsuarioId { get; set; }          // Usuario propietario del token
        public Guid SesionId { get; set; }           // Sesión a la que pertenece
        public string TokenHash { get; set; } = string.Empty;  // Hash del token
        public string? UserAgent { get; set; }       // Info del cliente
        public string? Ip { get; set; }              // IP origen

        public DateTime CreadoEn { get; set; } = DateTime.UtcNow;
        public DateTime ExpiraEn { get; set; }       // Fecha de expiración
        public DateTime? UsadoEn { get; set; }       // Fecha de uso
        public DateTime? RevocadoEn { get; set; }    // Fecha de revocación

        // Relaciones
        public Sesion Sesion { get; set; } = null!;
        public API_BASE.Domain.Entities.Usuario.Usuario Usuario { get; set; } = null!;
    }
}
