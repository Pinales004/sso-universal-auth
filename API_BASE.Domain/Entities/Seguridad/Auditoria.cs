using API_BASE.Domain.Base;
using API_BASE.Domain.Entities.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Domain.Entities.Seguridad
{
    public class Auditoria : AuditableEntity
    {
        public DateTime Fecha { get; set; }
        public Guid? ActorId { get; set; }                  // Usuario ejecutor
        public string Accion { get; set; }                  // Ej: LOGIN, LOGOUT, ASSIGN_ROLE, EVAL_PERM
        public string? ObjetivoTipo { get; set; }
        public string? ObjetivoId { get; set; }
        public Guid? OrganismoId { get; set; }
        public Guid? NodoId { get; set; }
        public string? Ip { get; set; }
        public string? UserAgent { get; set; }
        public string? Metadata { get; set; }               // JSON, claims, extra data

        public API_BASE.Domain.Entities.Usuario.Usuario? Actor { get; set; }
    }
}
