using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.DTOs.Seguridad
{
    public class UsuarioRolDto
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid RolId { get; set; }
        public Guid? OrganismoId { get; set; }
        public DateTime? Desde { get; set; }
        public DateTime? Hasta { get; set; }
    }
}
