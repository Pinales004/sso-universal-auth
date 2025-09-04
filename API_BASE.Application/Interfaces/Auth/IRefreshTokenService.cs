using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.DTOs.Auth
{
    public interface IRefreshTokenService
    {
        Task<string> GenerateRefreshTokenAsync(Guid usuarioId, Guid sessionId, string userAgent, string ip, CancellationToken ct);
        Task<bool> ValidateAndUseRefreshTokenAsync(string refreshToken, CancellationToken ct);
        Task RevokeAllAsync(Guid usuarioId, CancellationToken ct);
    }
}
