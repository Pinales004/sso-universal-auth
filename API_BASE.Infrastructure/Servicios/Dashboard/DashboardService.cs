using API_BASE.Application.DTOs.Dashboard;
using API_BASE.Application.Interfaces;
using API_BASE.Application.Interfaces.Dashboard;
using API_BASE.Domain.Entities.Usuario;
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
        private readonly IRepository<Usuario, Guid> _usuarioRepo;

        public DashboardService(IRepository<Usuario, Guid> usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
        }

        public async Task<UsuariosPorEstadoDto> ObtenerTotalUsuariosAsync(CancellationToken ct)
        {
            var usuarios = await _usuarioRepo.GetAllAsync(ct);

            var dto = new UsuariosPorEstadoDto
            {
                TotalUsuarios = usuarios.Count,
                Activos = usuarios.Count(u => u.Estado == Domain.Enums.EstadoUsuario.Activo),
                Inactivos = usuarios.Count(u => u.Estado == Domain.Enums.EstadoUsuario.Inactivos)
            };

            return dto;
        }

        // Implementa otros métodos...
    }
}
