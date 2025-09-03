using API_BASE.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Domain.Entities.Usuario.Solicitud
{
    public class SolicitudUsuario : AuditableEntity
    {
        public string Tipo { get; set; }          // Ej: "NuevaCuenta", "CambioRol"
        public Guid? SolicitanteId { get; set; }
        public string? EmailContacto { get; set; }
        public Guid? OrganismoId { get; set; }
        public Guid? NodoId { get; set; }
        public Guid? RolId { get; set; }
        public string? Detalle { get; set; }      // JSON, info extra
        public string Estado { get; set; }        // "Pendiente", "Aprobado", "Rechazado"
        public Guid? ResueltoPor { get; set; }
        public string? ComentarioResolucion { get; set; }

        public API_BASE.Domain.Entities.Usuario.Usuario? Solicitante { get; set; }
    }
}
