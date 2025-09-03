using API_BASE.Application.DTOs.Dashboard;
using API_BASE.Application.Interfaces.Dashboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_BASE.API.Controllers.Dashboard
{
    [ApiController]
    [Route("dashboard")]
    [Authorize(Roles = "Admin, Auditor")] // Usa tu sistema de roles
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _service;

        public DashboardController(IDashboardService service)
        {
            _service = service;
        }

        [HttpGet("usuarios/por-estado")]
        public async Task<ActionResult<UsuariosPorEstadoDto>> GetUsuariosPorEstado(CancellationToken ct)
            => Ok(await _service.GetUsuariosPorEstadoAsync(ct));

        [HttpGet("sesiones/activas")]
        public async Task<ActionResult<SesionesActivasDto>> GetSesionesActivas(CancellationToken ct)
            => Ok(await _service.GetSesionesActivasAsync(ct));

        [HttpGet("login/fallidos")]
        public async Task<ActionResult<LoginsFallidosDto>> GetLoginsFallidos([FromQuery] DateTime desde, CancellationToken ct)
            => Ok(await _service.GetLoginsFallidosAsync(desde, ct));

        [HttpGet("usuarios/por-organismo")]
        public async Task<ActionResult<List<UsuariosPorOrganismoDto>>> GetUsuariosPorOrganismo(CancellationToken ct)
            => Ok(await _service.GetUsuariosPorOrganismoAsync(ct));

        // Agrega más endpoints según sea necesario.
    }
}

