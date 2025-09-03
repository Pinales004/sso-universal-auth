using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.DTOs.Usuario
{
    public class MfaRecoveryCodeDto
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public string CodeHash { get; set; }
        public DateTime? UsadoEn { get; set; }
    }
}
