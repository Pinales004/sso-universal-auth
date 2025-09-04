using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.DTOs.Auth
{
    public interface IRefreshTokenService
    {
        /// <summary>
        /// Genera un nuevo refresh token para la sesión y el usuario especificado.
        /// </summary>
        /// <param name="usuarioId">ID del usuario</param>
        /// <param name="sessionId">ID de la sesión</param>
        /// <param name="userAgent">Información del cliente</param>
        /// <param name="ip">IP del cliente</param>
        /// <param name="ct">CancellationToken</param>
        Task<string> GenerateRefreshTokenAsync(Guid usuarioId, Guid sessionId, string userAgent, string ip, CancellationToken ct);

        /// <summary>
        /// Valida un refresh token y lo marca como usado.
        /// </summary>
        Task<bool> ValidateAndUseRefreshTokenAsync(string refreshToken, CancellationToken ct);

        /// <summary>
        /// Revoca todos los refresh tokens de un usuario.
        /// </summary>
        Task RevokeAllAsync(Guid usuarioId, CancellationToken ct);
    }
}
