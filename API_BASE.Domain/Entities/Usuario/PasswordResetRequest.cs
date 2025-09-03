using API_BASE.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Domain.Entities.Usuario
{
    public class PasswordResetRequest : AuditableEntity
    {
        public Guid UsuarioId { get; set; }
        public string TokenHash { get; set; }
        public DateTime SolicitadoEn { get; set; }
        public DateTime ExpiraEn { get; set; }
        public DateTime? UsadoEn { get; set; }
        public string? Ip { get; set; }
        public string? UserAgent { get; set; }
        public string Estado { get; set; }       // "Pendiente", "Usado", "Expirado"

        public Usuario Usuario { get; set; }
    }
}
