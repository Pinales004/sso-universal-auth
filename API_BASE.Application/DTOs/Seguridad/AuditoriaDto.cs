using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.DTOs.Seguridad
{
    public class AuditoriaDto
    {
        public Guid Id { get; set; }
        public DateTime Fecha { get; set; }
        public Guid? ActorId { get; set; }
        public string Accion { get; set; }
        public string? ObjetivoTipo { get; set; }
        public string? ObjetivoId { get; set; }
        public Guid? OrganismoId { get; set; }
        public Guid? NodoId { get; set; }
        public string? Ip { get; set; }
        public string? UserAgent { get; set; }
        public string? Metadata { get; set; }
    }
}
