using API_BASE.Application.Interfaces;
using API_BASE.Application.Interfaces.Servicios;
using API_BASE.Domain.Entities.Notificaciones;
using API_BASE.Domain.Entities.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Infrastructure.Servicios.Notification
{

    public class NotificationService : INotificationService
    {
        private readonly IRepository<Notificacion, Guid> _repo;
    private readonly IEmailSender _emailSender;
    private readonly IRepository<Usuario, Guid> _usuarioRepo;

    public NotificationService(IRepository<Notificacion, Guid> repo, IEmailSender emailSender, IRepository<Usuario, Guid> usuarioRepo)
    {
        _repo = repo;
        _emailSender = emailSender;
        _usuarioRepo = usuarioRepo;
    }

    // --------------------------
    // Enviar a un usuario
    // --------------------------
    public async Task SendAsync(string titulo, string mensaje, Guid usuarioId, string canal = "Sistema", string? url = null)
    {
        var notificacion = new Notificacion
        {
            Id = Guid.NewGuid(),
            Titulo = titulo,
            Mensaje = mensaje,
            Tipo = canal,
            UrlDestino = url,
            FechaEnvio = DateTime.UtcNow,
            EsGlobal = false
        };

        notificacion.Destinatarios.Add(new NotificacionUsuario
        {
            UsuarioId = usuarioId,
            NotificacionId = notificacion.Id
        });

        await _repo.AddAsync(notificacion, CancellationToken.None);
        await _repo.SaveChangesAsync(CancellationToken.None);

        // Obtener email del usuario
        var usuario = await _usuarioRepo.GetByIdAsync(usuarioId, CancellationToken.None);
        if (usuario != null && !string.IsNullOrEmpty(usuario.EmailContacto))
        {
            await _emailSender.SendEmailAsync(usuario.EmailContacto, titulo, mensaje);
        }
    }

    // --------------------------
    // Enviar a muchos usuarios
    // --------------------------
    public async Task SendToManyAsync(string titulo, string mensaje, IEnumerable<Guid> usuarios, string canal = "Sistema", string? url = null)
    {
        var notificacion = new Notificacion
        {
            Id = Guid.NewGuid(),
            Titulo = titulo,
            Mensaje = mensaje,
            Tipo = canal,
            UrlDestino = url,
            FechaEnvio = DateTime.UtcNow,
            EsGlobal = false
        };

        foreach (var usuarioId in usuarios)
        {
            notificacion.Destinatarios.Add(new NotificacionUsuario
            {
                UsuarioId = usuarioId,
                NotificacionId = notificacion.Id
            });
        }

        await _repo.AddAsync(notificacion, CancellationToken.None);
        await _repo.SaveChangesAsync(CancellationToken.None);

        // Enviar emails en paralelo
        var tasks = new List<Task>();
        foreach (var usuarioId in usuarios)
        {
            var usuario = await _usuarioRepo.GetByIdAsync(usuarioId, CancellationToken.None);
            if (usuario != null && !string.IsNullOrEmpty(usuario.EmailContacto))
            {
                tasks.Add(_emailSender.SendEmailAsync(usuario.EmailContacto, titulo, mensaje));
            }
        }
        await Task.WhenAll(tasks);
    }
}
}