using API_BASE.Application.DTOs.Usuario.Solicitud;
using API_BASE.Application.Interfaces;
using API_BASE.Application.Interfaces.Requests;
using API_BASE.Domain.Entities.Usuario.Solicitud;
using API_BASE.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Infrastructure.Servicios.Requests
{
    public class RequestService : IRequestService
    {
        private readonly IRepository<SolicitudUsuario, int> _repo;

        public RequestService(IRepository<SolicitudUsuario, int> repo)
        {
            _repo = repo;
        }

        // Crear nueva solicitud
        public async Task<Guid> CrearSolicitudAsync(SolicitudDto solicitudDto, CancellationToken ct)
        {
            var entidad = new SolicitudUsuario
            {
                Tipo = solicitudDto.Tipo,
                SolicitanteId = solicitudDto.SolicitanteId,
                EmailContacto = solicitudDto.EmailContacto,
                OrganismoId = solicitudDto.OrganismoId,
                NodoId = solicitudDto.NodoId,
                RolId = solicitudDto.RolId,
                Detalle = solicitudDto.Detalle,
                Estado = solicitudDto.Estado,
                ResueltoPor = solicitudDto.ResueltoPor,
                ComentarioResolucion = solicitudDto.ComentarioResolucion,
                FechaCreacion = DateTime.UtcNow
            };

            await _repo.AddAsync(entidad, ct);
            await _repo.SaveChangesAsync(ct);

            return entidad.Id; // Retorna Guid ahora
        }

        // Aprobar solicitud
        public async Task AprobarSolicitudAsync(Guid solicitudId, Guid aprobadorId, string comentario, CancellationToken ct)
        {
            var solicitud = await _repo.GetByIdAsync(solicitudId, ct);
            if (solicitud == null) throw new Exception("Solicitud no encontrada");

            solicitud.Estado = "Aprobado";
            solicitud.ResueltoPor = aprobadorId;
            solicitud.ComentarioResolucion = comentario;
            solicitud.FechaModificacion = DateTime.UtcNow;

            _repo.Update(solicitud);
            await _repo.SaveChangesAsync(ct);
        }
        // Rechazar solicitud
        public async Task RechazarSolicitudAsync(Guid solicitudId, Guid aprobadorId, string comentario, CancellationToken ct)
        {
            var solicitud = await _repo.GetByIdAsync(solicitudId, ct);
            if (solicitud == null) throw new Exception("Solicitud no encontrada");

            solicitud.Estado = "Rechazado";
            solicitud.ResueltoPor = aprobadorId;
            solicitud.ComentarioResolucion = comentario;
            solicitud.FechaModificacion = DateTime.UtcNow;

            _repo.Update(solicitud);
            await _repo.SaveChangesAsync(ct);
        }

        // Listar solicitudes con filtro opcional
        public async Task<IEnumerable<SolicitudDto>> ListarSolicitudesAsync(SolicitudFiltroDto filtro, CancellationToken ct)
        {
            var query = _repo.Query();

            //if (filtro.SolicitanteId.HasValue)
            //    query = query.Where(x => x.SolicitanteId == filtro.SolicitanteId.Value);

            //if (!string.IsNullOrEmpty(filtro.Tipo))
            //    query = query.Where(x => x.Tipo == filtro.Tipo);

            if (!string.IsNullOrEmpty(filtro.Estado))
                query = query.Where(x => x.Estado == filtro.Estado);

            var list = await query.ToListAsync(ct);

            return list.Select(x => new SolicitudDto
            {
                Tipo = x.Tipo,
                //SolicitanteId = x.SolicitanteId,
                EmailContacto = x.EmailContacto,
                OrganismoId = x.OrganismoId,
                NodoId = x.NodoId,
                RolId = x.RolId,
                Detalle = x.Detalle,
                Estado = x.Estado,
                ResueltoPor = x.ResueltoPor,
                ComentarioResolucion = x.ComentarioResolucion
            });
        }
    }
}
