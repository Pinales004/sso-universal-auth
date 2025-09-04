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
        public Guid UsuarioId { get; set; }          // Usuario al que pertenece
        public string CodeHash { get; set; } = string.Empty;  // Código hasheado
        public bool Usado { get; set; } = false;     // Marca si el código ya se utilizó
        public DateTime CreadoEn { get; set; } = DateTime.UtcNow;
        public DateTime? UsadoEn { get; set; }       // Fecha de uso



        public Usuario Usuario { get; set; }
    }
}
