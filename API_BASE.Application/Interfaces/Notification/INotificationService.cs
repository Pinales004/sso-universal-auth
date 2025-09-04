using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.Interfaces.Servicios
{
    public interface INotificationService
    {
        /// <summary>
        /// Envía una notificación a un solo usuario.
        /// </summary>
        /// <param name="titulo">Título de la notificación</param>
        /// <param name="mensaje">Contenido del mensaje</param>
        /// <param name="usuarioId">ID del usuario destinatario</param>
        /// <param name="canal">Canal de envío: Email, SMS, Push, Sistema (default)</param>
        /// <param name="url">Opcional: URL asociada a la notificación</param>
        Task SendAsync(string titulo, string mensaje, Guid usuarioId, string canal = "Sistema", string? url = null);

        /// <summary>
        /// Envía una notificación a múltiples usuarios.
        /// </summary>
        /// <param name="titulo">Título de la notificación</param>
        /// <param name="mensaje">Contenido del mensaje</param>
        /// <param name="usuarios">Lista de IDs de usuarios destinatarios</param>
        /// <param name="canal">Canal de envío: Email, SMS, Push, Sistema (default)</param>
        /// <param name="url">Opcional: URL asociada a la notificación</param>
        Task SendToManyAsync(string titulo, string mensaje, IEnumerable<Guid> usuarios, string canal = "Sistema", string? url = null);
    }
}
