using API_BASE.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Domain.Entities.Seguridad
{
    public class RefreshToken : AuditableEntity
    {
        public Guid SesionId { get; set; }
        public string TokenHash { get; set; }
        public DateTime ExpiraEn { get; set; }
        public DateTime? UsadoEn { get; set; }
        public DateTime? RevocadoEn { get; set; }

        public Sesion Sesion { get; set; }
    }
}
