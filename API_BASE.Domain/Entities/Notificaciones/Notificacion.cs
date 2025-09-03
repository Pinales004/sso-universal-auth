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
        public string Titulo { get; set; }
        public string Mensaje { get; set; }
        public string Tipo { get; set; }         // Ej: "Email", "SMS", "Push", "Sistema"
        public string? UrlDestino { get; set; }
        public DateTime FechaEnvio { get; set; }
        public bool EsGlobal { get; set; } = false;   // Si aplica a todos los usuarios o no

        public ICollection<NotificacionUsuario> Destinatarios { get; set; } = new List<NotificacionUsuario>();
    }
}
