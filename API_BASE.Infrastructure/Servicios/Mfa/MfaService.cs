using API_BASE.Application.Interfaces.Auth;
using API_BASE.Application.Interfaces;
using API_BASE.Domain.Entities.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_BASE.Application.Interfaces.Mfa;
using API_BASE.Application.DTOs;

namespace API_BASE.Infrastructure.Servicios.Mfa
{
    public class MfaService : IMfaService
    {

        private readonly IRepository<MfaTotp, Guid> _totpRepo;
        private readonly IRepository<MfaRecoveryCode, Guid> _recoveryRepo;
        private readonly ITotpService _totpService;
        private readonly IPasswordHasher _hasher;

        public MfaService(
            IRepository<MfaTotp, Guid> totpRepo,
            IRepository<MfaRecoveryCode, Guid> recoveryRepo,
            ITotpService totpService,
            IPasswordHasher hasher)
        {
            _totpRepo = totpRepo;
            _recoveryRepo = recoveryRepo;
            _totpService = totpService;
            _hasher = hasher;
        }

        public async Task<MfaSetupResult> ActivarMfaAsync(Guid usuarioId, CancellationToken ct)
        {
            var secret = _totpService.GenerateSecret();
            var qr = _totpService.GenerateQrCode("SSO", usuarioId.ToString(), secret);

            var totp = new MfaTotp
            {
                Id = Guid.NewGuid(),
                UsuarioId = usuarioId,
                Secret = secret,
                Habilitado = true,
                FechaCreacion = DateTime.UtcNow
            };

            await _totpRepo.AddAsync(totp, ct);
            await _totpRepo.SaveChangesAsync(ct);

            return new MfaSetupResult
            {
                QrCodeImageBase64 = qr,
                ManualEntryKey = secret,
                Success = true
            };
        }

        public async Task<bool> ValidarMfaAsync(Guid usuarioId, string code, CancellationToken ct)
        {
            var totp = await _totpRepo.FirstOrDefaultAsync(x => x.UsuarioId == usuarioId, ct);
            if (totp == null) return false;

            return _totpService.ValidateCode(totp.Secret, code);
        }

        public async Task DesactivarMfaAsync(Guid usuarioId, CancellationToken ct)
        {
            var totp = await _totpRepo.FirstOrDefaultAsync(x => x.UsuarioId == usuarioId, ct);
            if (totp != null)
            {
                totp.Habilitado = false;
                await _totpRepo.SaveChangesAsync(ct);
            }
        }

        public async Task<List<string>> GenerarRecoveryCodesAsync(Guid usuarioId, CancellationToken ct)
        {
            var codes = _totpService.GenerateRecoveryCodes();

            foreach (var code in codes)
            {
                var entity = new MfaRecoveryCode
                {
                    Id = Guid.NewGuid(),
                    UsuarioId = usuarioId,
                    CodeHash = _hasher.HashPassword(code, out _),
                    Usado = false,
                    CreadoEn = DateTime.UtcNow
                };
                await _recoveryRepo.AddAsync(entity, ct);
            }

            await _recoveryRepo.SaveChangesAsync(ct);
            return codes;
        }

        public async Task<bool> UsarRecoveryCodeAsync(Guid usuarioId, string code, CancellationToken ct)
        {
            string hash = _hasher.HashPassword(code, out _);

            var entity = await _recoveryRepo.FirstOrDefaultAsync(
                x => x.UsuarioId == usuarioId && x.CodeHash == hash && !x.Usado,
                ct);

            if (entity == null) return false;

            entity.Usado = true;
            entity.UsadoEn = DateTime.UtcNow;

            _recoveryRepo.Update(entity);
            await _recoveryRepo.SaveChangesAsync(ct);

            return true;
        }
    }
 }   