using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.DTOs.Seguridad
{
    public class SesionDto
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public string? Ip { get; set; }
        public string? UserAgent { get; set; }
        public DateTime? ExpiraEn { get; set; }
        public DateTime? RevocadoEn { get; set; }
        public string? MotivoRevocacion { get; set; }
    }
}
