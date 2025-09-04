using API_BASE.Application.DTOs.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.Interfaces.Usuario
{
    public interface IUsuario
    {
        Task<bool> EmailExistsAsync(string email, CancellationToken ct = default);
        Task CambiarPasswordAsync(Guid usuarioId, string nuevaPassword, CancellationToken ct = default);
    }
}
