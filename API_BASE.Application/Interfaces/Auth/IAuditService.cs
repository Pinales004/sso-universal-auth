using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.Interfaces.Auth
{
    public interface IAuditService
    {
        Task RegistrarEventoAsync(AuditEvent auditEvent, CancellationToken ct);
    }

    public class AuditEvent
    {
        public string Accion { get; set; } = string.Empty; // LOGIN, LOGOUT, ASSIGN_ROLE, etc
        public int? ActorId { get; set; }
        public string? ObjetivoTipo { get; set; }
        public string? ObjetivoId { get; set; }
        public int? OrganismoIdExt { get; set; }
        public int? NodoId { get; set; }
        public string? Ip { get; set; }
        public string? UserAgent { get; set; }
        public string? MetadataJson { get; set; }
        public DateTime Fecha { get; set; } = DateTime.UtcNow;
    }
}
