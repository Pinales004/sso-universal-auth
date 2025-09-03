using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.DTOs.Notificaciones
{
    public class NotificacionDto
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Mensaje { get; set; }
        public string Tipo { get; set; }
        public string? UrlDestino { get; set; }
        public DateTime FechaEnvio { get; set; }
        public bool EsGlobal { get; set; }
    }
}
