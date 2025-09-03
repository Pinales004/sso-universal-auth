using API_BASE.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Domain.Entities.Usuario
{
    public class PasswordHistory : AuditableEntity
    {
        public Guid UsuarioId { get; set; }
        public string PasswordHash { get; set; }
        public DateTime FechaCambio { get; set; }

        public Usuario Usuario { get; set; }
    }
}
