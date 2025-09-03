using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.Interfaces.Servicios
{
    public interface INotificationService
    {
        Task SendAsync(string titulo, string mensaje, Guid usuarioId, string canal = "Sistema", string? url = null);
        Task SendToManyAsync(string titulo, string mensaje, IEnumerable<Guid> usuarios, string canal = "Sistema", string? url = null);
    }
}
