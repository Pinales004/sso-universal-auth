using API_BASE.Application.DTOs.Auth;
using API_BASE.Application.Interfaces;
using API_BASE.Application.Interfaces.Auth;
using API_BASE.Domain.Entities.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Infrastructure.Servicios.Auth
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IRepository<RefreshToken, Guid> _repo;
        private readonly IPasswordHasher _hasher;

        public RefreshTokenService(IRepository<RefreshToken, Guid> repo, IPasswordHasher hasher)
        {
            _repo = repo;
            _hasher = hasher;
        }

        public async Task<string> GenerateRefreshTokenAsync(Guid usuarioId, Guid sessionId, string userAgent, string ip, CancellationToken ct)
        {
            var refreshToken = Guid.NewGuid().ToString("N");
            var hash = _hasher.HashPassword(refreshToken, out _);

            var entity = new RefreshToken
            {
                Id = Guid.NewGuid(),
                UsuarioId = usuarioId,
                SesionId = sessionId,
                TokenHash = hash,
                UserAgent = userAgent,
                Ip = ip,
                CreadoEn = DateTime.UtcNow,
                ExpiraEn = DateTime.UtcNow.AddDays(7)
            };

            await _repo.AddAsync(entity, ct);
            await _repo.SaveChangesAsync(ct);
            return refreshToken;
        }

        public async Task<bool> ValidateAndUseRefreshTokenAsync(string refreshToken, CancellationToken ct)
        {
            var hash = _hasher.HashPassword(refreshToken, out _);
            var token = await _repo.FirstOrDefaultAsync(t => t.TokenHash == hash && t.UsadoEn == null && t.RevocadoEn == null, ct);
            if (token == null || token.ExpiraEn < DateTime.UtcNow) return false;

            token.UsadoEn = DateTime.UtcNow;
            _repo.Update(token);
            await _repo.SaveChangesAsync(ct);
            return true;
        }

        public async Task RevokeAllAsync(Guid usuarioId, CancellationToken ct)
        {
            var tokens = await _repo.FindAsync(t => t.UsuarioId == usuarioId && t.RevocadoEn == null, ct);
            foreach (var t in tokens)
            {
                t.RevocadoEn = DateTime.UtcNow;
                _repo.Update(t);
            }
            await _repo.SaveChangesAsync(ct);
        }
    }
}
