using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.DTOs.Organizacion
{
    public class UsuarioOrganizacionDto
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid OrganismoId { get; set; }
        public bool EsPrincipal { get; set; }
        public DateTime? Desde { get; set; }
        public DateTime? Hasta { get; set; }
    }
}
