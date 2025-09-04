using API_BASE.Application.DTOs.Usuario.Solicitud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.Interfaces.Requests
{
    public interface IRequestService
    {
        Task<Guid> CrearSolicitudAsync(SolicitudDto solicitud, CancellationToken ct);
        Task AprobarSolicitudAsync(Guid solicitudId, Guid aprobadorId, string comentario, CancellationToken ct);
        Task RechazarSolicitudAsync(Guid solicitudId, Guid aprobadorId, string comentario, CancellationToken ct);
        Task<IEnumerable<SolicitudDto>> ListarSolicitudesAsync(SolicitudFiltroDto filtro, CancellationToken ct);
    }
}
