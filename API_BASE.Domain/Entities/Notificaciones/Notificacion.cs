using API_BASE.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Domain.Entities.Notificaciones
{
    //Propósito: Registrar cada notificación generada por el sistema.
    public class Notificacion : AuditableEntity
    {
        public string Titulo { get; set; } = string.Empty;
        public string Mensaje { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty; // "Email", "SMS", "Push", "Sistema"
        public string? UrlDestino { get; set; }
        public DateTime FechaEnvio { get; set; } = DateTime.UtcNow;
        public bool EsGlobal { get; set; } = false; // Aplica a todos o no

        public ICollection<NotificacionUsuario> Destinatarios { get; set; } = new List<NotificacionUsuario>();
    }
}
