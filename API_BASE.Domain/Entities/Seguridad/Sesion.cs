using API_BASE.Domain.Base;
using API_BASE.Domain.Entities.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Domain.Entities.Seguridad
{
    public class Sesion : AuditableEntity
    {
        public Guid UsuarioId { get; set; }              // Usuario al que pertenece la sesión
        public string? Ip { get; set; }                  // IP desde donde se inició
        public string? UserAgent { get; set; }           // Información del cliente
        public DateTime? ExpiraEn { get; set; }          // Opcional, fecha de expiración de la sesión
        public DateTime? RevocadoEn { get; set; }        // Fecha en que se revocó la sesión
        public string? MotivoRevocacion { get; set; }    // Motivo de revocación, si aplica

        // Relaciones
        public API_BASE.Domain.Entities.Usuario.Usuario Usuario { get; set; } = null!;    // Navegación hacia el usuario
        public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    }
}
