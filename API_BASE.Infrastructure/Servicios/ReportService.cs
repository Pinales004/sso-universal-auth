using API_BASE.Application.DTOs.Reports;
using API_BASE.Application.Interfaces.Reports;
using API_BASE.Domain.Enums;
using API_BASE.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Infrastructure.Servicios
{
    public class ReportService  /*IReportService*/
    {
        private readonly ApplicationDbContext _context;

        public ReportService(ApplicationDbContext context)
        {
            _context = context;
        }

        //public async Task<byte[]> GenerarReporteUsuariosAsync(FiltroReporteUsuariosDTO filtro, CancellationToken ct)
        //{
        //    var query = _context.Usuarios.AsQueryable();

        //    if (!string.IsNullOrEmpty(filtro.Estado))
        //    {
        //        var estadoEnum = (EstadoUsuario)Enum.Parse(typeof(EstadoUsuario), filtro.Estado, true);
        //        query = query.Where(u => u.Estado == estadoEnum);
        //    }

        //    if (filtro.Desde.HasValue)
        //        query = query.Where(u => u.FechaCreacion >= filtro.Desde);

        //    if (filtro.Hasta.HasValue)
        //        query = query.Where(u => u.FechaCreacion <= filtro.Hasta);

        //    if (filtro.OrganismoId.HasValue)
        //        query = query.Where(u => u.Organizaciones.Any(x => x.OrganismoId == filtro.OrganismoId.Value));

        //    var usuarios = await query.ToListAsync(ct);

        //    using var ms = new MemoryStream();
        //    using var writer = new StreamWriter(ms, leaveOpen: true);
        //    using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
        //    csv.WriteRecords(usuarios); // Mapea a DTO según columnas visibles
        //    writer.Flush();
        //    ms.Position = 0;
        //    return ms.ToArray();
        //}

        // Similar para auditoría, roles, etc.
    }
}
