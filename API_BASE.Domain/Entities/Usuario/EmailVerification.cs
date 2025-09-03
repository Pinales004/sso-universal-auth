using API_BASE.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Domain.Entities.Usuario
{
    public class EmailVerification : AuditableEntity
    {
        public Guid UsuarioId { get; set; }
        public string Email { get; set; }
        public string TokenHash { get; set; }
        public DateTime SolicitadoEn { get; set; }
        public DateTime ExpiraEn { get; set; }
        public DateTime? VerificadoEn { get; set; }

        public Usuario Usuario { get; set; }
    }
}
