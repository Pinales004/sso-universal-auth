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
        public Guid UsuarioId { get; set; }
        public string? Ip { get; set; }
        public string? UserAgent { get; set; }
        public DateTime? ExpiraEn { get; set; }
        public DateTime? RevocadoEn { get; set; }
        public string? MotivoRevocacion { get; set; }

        public API_BASE.Domain.Entities.Usuario.Usuario Usuario { get; set; }
        public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    }
}
