using API_BASE.Application.DTOs.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.Interfaces.Reports
{
    public interface IReportService
    {
        Task<byte[]> GenerarReporteUsuariosAsync(FiltroReporteUsuariosDTO filtro, CancellationToken ct);
        public async Task<byte[]> GenerarReporteAuditoriaAsync(FiltroReporteUsuariosDTO filtro, CancellationToken ct)
        {
            // Implementa la lógica aquí, aunque sea un return vacío temporal:
            return Array.Empty<byte>();
        }
    }
}
