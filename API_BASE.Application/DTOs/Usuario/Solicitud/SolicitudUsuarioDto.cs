using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.DTOs.Usuario.Solicitud
{
    public class SolicitudUsuarioDto
    {
        public Guid Id { get; set; }
        public string Tipo { get; set; }
        public Guid? SolicitanteId { get; set; }
        public string? EmailContacto { get; set; }
        public Guid? OrganismoId { get; set; }
        public Guid? NodoId { get; set; }
        public Guid? RolId { get; set; }
        public string? Detalle { get; set; }
        public string Estado { get; set; }
        public Guid? ResueltoPor { get; set; }
        public string? ComentarioResolucion { get; set; }
    }
}
