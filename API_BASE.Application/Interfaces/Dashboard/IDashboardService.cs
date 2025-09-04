using API_BASE.Application.DTOs.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.Interfaces.Dashboard
{
    public interface IDashboardService
    {
        Task<UsuariosPorEstadoDto> ObtenerTotalUsuariosAsync(CancellationToken ct);
        //Task<SesionesActivasDto> GetSesionesActivasAsync(CancellationToken ct);
        //Task<LoginsFallidosDto> GetLoginsFallidosAsync(DateTime desde, CancellationToken ct);
        //Task<List<UsuariosPorOrganismoDto>> GetUsuariosPorOrganismoAsync(CancellationToken ct);
        // Otros métodos para los demás widgets.
    }
}
