using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.DTOs.Seguridad
{
    public class RefreshTokenDto
    {
        public Guid Id { get; set; }
        public Guid SesionId { get; set; }
        public string TokenHash { get; set; }
        public DateTime ExpiraEn { get; set; }
        public DateTime? UsadoEn { get; set; }
        public DateTime? RevocadoEn { get; set; }
    }
}
