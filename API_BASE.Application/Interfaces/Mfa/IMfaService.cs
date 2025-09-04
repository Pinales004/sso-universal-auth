using API_BASE.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.Interfaces.Mfa
{
    public interface IMfaService
    {
        /// <summary>
        /// Activa MFA para un usuario y genera el secreto TOTP.
        /// </summary>
        Task<MfaSetupResult> ActivarMfaAsync(Guid usuarioId, CancellationToken ct);

        /// <summary>
        /// Valida un código TOTP proporcionado por el usuario.
        /// </summary>
        Task<bool> ValidarMfaAsync(Guid usuarioId, string code, CancellationToken ct);

        /// <summary>
        /// Desactiva MFA para un usuario.
        /// </summary>
        Task DesactivarMfaAsync(Guid usuarioId, CancellationToken ct);

        /// <summary>
        /// Genera códigos de recuperación para MFA.
        /// </summary>
        Task<List<string>> GenerarRecoveryCodesAsync(Guid usuarioId, CancellationToken ct);

        /// <summary>
        /// Marca un código de recuperación como usado.
        /// </summary>
        Task<bool> UsarRecoveryCodeAsync(Guid usuarioId, string code, CancellationToken ct);
    }
}
