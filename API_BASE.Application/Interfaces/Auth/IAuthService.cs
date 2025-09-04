using API_BASE.Application.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.Interfaces.Auth
{
    public interface IAuthService
    {
        Task<AuthResult> LoginAsync(string email, string password, string? mfaCode, string userAgent, string ip, CancellationToken ct);
        Task<AuthResult> RefreshTokenAsync(string refreshToken, string userAgent, string ip, CancellationToken ct);
        Task LogoutAsync(Guid usuarioId, string refreshToken, CancellationToken ct);
    }
}
