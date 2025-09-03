using API_BASE.Domain.Base;
using API_BASE.Domain.Entities.Mantenimiento.Aplicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Domain.Entities.Aplicacion
{
    public class Aplicacion : AuditableEntity
    {
        public string Nombre { get; set; }                  // Nombre de la app/sistema
        public string Codigo { get; set; }                  // Código único (para validaciones internas)
        public string? Descripcion { get; set; }
        public string? RedirectUri { get; set; }            // Para flujos OAuth2/OpenID (opcional)
        public string? ClientId { get; set; }               // Para clientes OAuth2 (opcional)
        public string? ClientSecret { get; set; }           // Para flujos confidenciales (opcional)
        public ICollection<AplicacionPermiso> Permisos { get; set; } = new List<AplicacionPermiso>();
    }
}
