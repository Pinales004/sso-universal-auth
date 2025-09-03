using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.Interfaces.Servicios
{
    public interface IAuditoriaService
    {
        Task RegistrarAccionAsync(Guid? usuarioId, string accion, string? objetivoTipo = null, string? objetivoId = null, string? metadata = null);
    }
}
