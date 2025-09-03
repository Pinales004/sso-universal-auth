using API_BASE.Domain.Base;
using API_BASE.Domain.Entities.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Domain.Entities.Notificaciones
{
    public class NotificacionUsuario : AuditableEntity
    {
        public Guid NotificacionId { get; set; }
        public Guid UsuarioId { get; set; }
        public bool Leida { get; set; } = false;
        public DateTime? FechaLectura { get; set; }
        public bool Entregada { get; set; } = false;
        public DateTime? FechaEntrega { get; set; }

        public Notificacion Notificacion { get; set; }
        public API_BASE.Domain.Entities.Usuario.Usuario Usuario { get; set; }
    }
}
