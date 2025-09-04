using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.DTOs.Usuario.Solicitud
{
    public class SolicitudDto
    {
        /// <summary>
        /// Tipo de solicitud: "NuevaCuenta", "CambioRol", etc.
        /// </summary>
        public string Tipo { get; set; } = string.Empty;

        /// <summary>
        /// Usuario que solicita
        /// </summary>
        public Guid SolicitanteId { get; set; }

        /// <summary>
        /// Email de contacto opcional
        /// </summary>
        public string? EmailContacto { get; set; }

        /// <summary>
        /// Organismo al que se aplica la solicitud
        /// </summary>
        public Guid? OrganismoId { get; set; }

        /// <summary>
        /// Nodo al que aplica
        /// </summary>
        public Guid? NodoId { get; set; }

        /// <summary>
        /// Rol que se desea asignar (si aplica)
        /// </summary>
        public Guid? RolId { get; set; }

        /// <summary>
        /// Detalles extras en formato JSON u otro
        /// </summary>
        public string? Detalle { get; set; }

        /// <summary>
        /// Estado inicial: "Pendiente", "Aprobado", "Rechazado"
        /// </summary>
        public string Estado { get; set; } = "Pendiente";

        /// <summary>
        /// Usuario que resolvió la solicitud
        /// </summary>
        public Guid? ResueltoPor { get; set; }

        /// <summary>
        /// Comentario de resolución
        /// </summary>
        public string? ComentarioResolucion { get; set; }
    }

    public class SolicitudFiltroDto
    {
        public string? Estado { get; set; }
        public int? OrganismoIdExt { get; set; }
        public int? NodoId { get; set; }
        public int? RolId { get; set; }
        public int? SolicitanteId { get; set; }
        public DateTime? Desde { get; set; }
        public DateTime? Hasta { get; set; }
    }
}
