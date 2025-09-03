using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.DTOs.Usuario
{
    public class PasswordResetRequestDto
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public string TokenHash { get; set; }
        public DateTime SolicitadoEn { get; set; }
        public DateTime ExpiraEn { get; set; }
        public DateTime? UsadoEn { get; set; }
        public string? Ip { get; set; }
        public string? UserAgent { get; set; }
        public string Estado { get; set; }
    }
}
