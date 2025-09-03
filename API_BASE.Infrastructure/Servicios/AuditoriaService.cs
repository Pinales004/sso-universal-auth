using API_BASE.Application.Interfaces.Servicios;
using API_BASE.Domain.Entities.Seguridad;
using API_BASE.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Infrastructure.Servicios
{
    public class AuditoriaService : IAuditoriaService
    {
        private readonly ApplicationDbContext _db;
        public AuditoriaService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task RegistrarAccionAsync(Guid? usuarioId, string accion, string? objetivoTipo = null, string? objetivoId = null, string? metadata = null)
        {
            var auditoria = new Auditoria
            {
                Fecha = DateTime.UtcNow,
                ActorId = usuarioId,
                Accion = accion,
                ObjetivoTipo = objetivoTipo,
                ObjetivoId = objetivoId,
                Metadata = metadata
            };
            _db.Auditorias.Add(auditoria);
            await _db.SaveChangesAsync();
        }
    }
}
