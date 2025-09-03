using API_BASE.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Domain.Entities.Usuario
{
    //Para códigos de respaldo de MFA.
    public class MfaRecoveryCode : AuditableEntity
    {
        public Guid UsuarioId { get; set; }
        public string CodeHash { get; set; }
        public DateTime? UsadoEn { get; set; }

        public Usuario Usuario { get; set; }
    }
}
