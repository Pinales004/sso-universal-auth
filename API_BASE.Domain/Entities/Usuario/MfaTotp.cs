using API_BASE.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Domain.Entities.Usuario
{

    //Para configuración de segundo factor TOTP.
    public class MfaTotp : AuditableEntity
    {
        public Guid UsuarioId { get; set; }
        public string Secret { get; set; }         // Secreto cifrado
        public bool Habilitado { get; set; }
        public DateTime? DeshabilitadoEn { get; set; }

        public Usuario Usuario { get; set; }
    }
}
