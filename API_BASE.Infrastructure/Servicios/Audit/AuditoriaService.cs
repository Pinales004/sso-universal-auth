using API_BASE.Application.Interfaces;
using API_BASE.Application.Interfaces.Servicios;
using API_BASE.Domain.Entities.Seguridad;
using API_BASE.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Infrastructure.Servicios.Audit
{
    public class AuditoriaService : IAuditoriaService
    {
        private readonly IRepository<Auditoria, Guid> _repo;

        public AuditoriaService(IRepository<Auditoria, Guid> repo)
        {
            _repo = repo;
        }

        //public async Task RegistrarEventoAsync(Auditoria evento, CancellationToken ct)
        //{
        //    await _repo.AddAsync(evento, ct);
        //    await _repo.SaveChangesAsync(ct);
        //}
    }
}
