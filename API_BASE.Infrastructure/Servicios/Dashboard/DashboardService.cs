using API_BASE.Application.DTOs.Dashboard;
using API_BASE.Application.Interfaces.Dashboard;
using API_BASE.Domain.Enums;
using API_BASE.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Infrastructure.Servicios.Dashboard
{
    public class DashboardService : IDashboardService
    {
        private readonly ApplicationDbContext _context;

        public DashboardService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UsuariosPorEstadoDto> GetUsuariosPorEstadoAsync(CancellationToken ct)
        {
            return new UsuariosPorEstadoDto
            {
                Activos = await _context.Usuarios.CountAsync(u => u.Estado == EstadoUsuario.Activo, ct),
                Suspendidos = await _context.Usuarios.CountAsync(u => u.Estado == EstadoUsuario.Suspendido, ct),
                Invitados = await _context.Usuarios.CountAsync(u => u.Estado == EstadoUsuario.Invitado, ct)
            };
        }

        public async Task<SesionesActivasDto> GetSesionesActivasAsync(CancellationToken ct)
        {
            var now = DateTime.UtcNow;
            var total = await _context.Sesiones
                .CountAsync(s => s.RevocadoEn == null && s.ExpiraEn > now, ct);

            return new SesionesActivasDto { Total = total };
        }

        public async Task<LoginsFallidosDto> GetLoginsFallidosAsync(DateTime desde, CancellationToken ct)
        {
            var cantidad = await _context.Auditorias
                .CountAsync(a => a.Accion == "LOGIN_FAIL" && a.Fecha >= desde, ct);

            return new LoginsFallidosDto { Cantidad = cantidad };
        }

        public async Task<List<UsuariosPorOrganismoDto>> GetUsuariosPorOrganismoAsync(CancellationToken ct)
        {
            return await _context.UsuarioOrganizaciones
                .Include(uo => uo.Organismo)
                .GroupBy(uo => uo.Organismo.Nombre)
                .Select(g => new UsuariosPorOrganismoDto
                {
                    Organismo = g.Key,
                    Usuarios = g.Count()
                })
                .ToListAsync(ct);
        }

        // Implementa otros métodos...
    }
}
