using API_BASE.Domain.Base;
using API_BASE.Domain.Entities.Usuario;
using API_BASE.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Domain.Entities.Organismo
{
    public class Organismo : AuditableEntity
    {

        public string Nombre { get; set; }
        public TipoOrganizacion Tipo { get; set; }
        public Guid? ParentId { get; set; }
        public string? Codigo { get; set; }
        // Relaciones jerárquicas internas (opcional)
        public Organismo? Padre { get; set; }
        public ICollection<Organismo> Hijos { get; set; } = new List<Organismo>();
        public ICollection<UsuarioOrganizacion> UsuarioOrganizaciones { get; set; } = new List<UsuarioOrganizacion>();
    }
}

