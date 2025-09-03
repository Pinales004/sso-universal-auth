using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.DTOs.Notificaciones
{
    public class NotificacionUsuarioDto
    {
        public Guid Id { get; set; }
        public Guid NotificacionId { get; set; }
        public Guid UsuarioId { get; set; }
        public bool Leida { get; set; }
        public DateTime? FechaLectura { get; set; }
        public bool Entregada { get; set; }
        public DateTime? FechaEntrega { get; set; }
    }
}
