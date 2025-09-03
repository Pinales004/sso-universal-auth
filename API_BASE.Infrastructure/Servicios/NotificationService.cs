using API_BASE.Application.Interfaces.Servicios;
using API_BASE.Domain.Entities.Notificaciones;
using API_BASE.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Infrastructure.Servicios
{
    public class NotificationService : INotificationService
    {
        private readonly ApplicationDbContext _db;

        public NotificationService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task SendAsync(string titulo, string mensaje, Guid usuarioId, string canal = "Sistema", string? url = null)
        {
            var notif = new Notificacion
            {
                Titulo = titulo,
                Mensaje = mensaje,
                Tipo = canal,
                UrlDestino = url,
                FechaEnvio = DateTime.UtcNow,
                EsGlobal = false
            };
            _db.Notificaciones.Add(notif);
            await _db.SaveChangesAsync();

            var nu = new NotificacionUsuario
            {
                NotificacionId = notif.Id,
                UsuarioId = usuarioId,
                Leida = false,
                Entregada = false
            };
            _db.NotificacionesUsuario.Add(nu);
            await _db.SaveChangesAsync();
        }

        public async Task SendToManyAsync(string titulo, string mensaje, IEnumerable<Guid> usuarios, string canal = "Sistema", string? url = null)
        {
            var notif = new Notificacion
            {
                Titulo = titulo,
                Mensaje = mensaje,
                Tipo = canal,
                UrlDestino = url,
                FechaEnvio = DateTime.UtcNow,
                EsGlobal = false
            };
            _db.Notificaciones.Add(notif);
            await _db.SaveChangesAsync();

            foreach (var uid in usuarios)
            {
                _db.NotificacionesUsuario.Add(new NotificacionUsuario
                {
                    NotificacionId = notif.Id,
                    UsuarioId = uid,
                    Leida = false,
                    Entregada = false
                });
            }
            await _db.SaveChangesAsync();
        }

        public async Task SendSystemAsync(string titulo, string mensaje, string? url = null)
        {
            var notif = new Notificacion
            {
                Titulo = titulo,
                Mensaje = mensaje,
                Tipo = "Sistema",
                UrlDestino = url,
                FechaEnvio = DateTime.UtcNow,
                EsGlobal = true
            };
            _db.Notificaciones.Add(notif);
            await _db.SaveChangesAsync();
        }
    }
}