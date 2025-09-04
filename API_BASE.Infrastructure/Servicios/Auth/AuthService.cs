using API_BASE.Application.DTOs.Auth;
using API_BASE.Application.Interfaces;
using API_BASE.Application.Interfaces.Auth;
using API_BASE.Application.Interfaces.Mfa;
using API_BASE.Application.Models.Auth;
using API_BASE.Domain.Entities.Seguridad;
using API_BASE.Domain.Entities.Usuario;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace API_BASE.Infrastructure.Servicios.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IRepository<Usuario, Guid> _usuarioRepo;
        private readonly IRepository<Sesion, Guid> _sesionRepo;
        private readonly IRepository<RefreshToken, Guid> _refreshRepo;
        private readonly IPasswordHasher _hasher;
        private readonly ITokenService _tokenService;
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly IMfaService _mfaService;

        public AuthService(
            IRepository<Usuario, Guid> usuarioRepo,
            IRepository<Sesion, Guid> sesionRepo,
            IRepository<RefreshToken, Guid> refreshRepo,
            IPasswordHasher hasher,
            ITokenService tokenService,
            IRefreshTokenService refreshTokenService,
            IMfaService mfaService)
        {
            _usuarioRepo = usuarioRepo;
            _sesionRepo = sesionRepo;
            _refreshRepo = refreshRepo;
            _hasher = hasher;
            _tokenService = tokenService;
            _refreshTokenService = refreshTokenService;
            _mfaService = mfaService;
        }

        public async Task<AuthResult> LoginAsync(string email, string password, string? mfaCode, string userAgent, string ip, CancellationToken ct)
        {
            var usuario = await _usuarioRepo.FirstOrDefaultAsync(u => u.Email == email, ct);
            if (usuario == null) return AuthResult.Fail("CREDENCIALES_INVALIDAS");

            if (!_hasher.VerifyPassword(password, usuario.PasswordHash, usuario.PasswordSalt))
                return AuthResult.Fail("CREDENCIALES_INVALIDAS");

            if (!usuario.Activo) return AuthResult.Fail("USUARIO_INACTIVO");

            if (usuario.MfaEnabled)
            {
                if (string.IsNullOrEmpty(mfaCode))
                    return new AuthResult { Success = false, RequiresMfa = true, ErrorCode = "MFA_REQUIRED" };

                if (!await _mfaService.ValidarMfaAsync(usuario.Id, mfaCode, ct))
                    return AuthResult.Fail("MFA_INVALIDO");
            }

            var sesion = new Sesion
            {
                Id = Guid.NewGuid(),
                UsuarioId = usuario.Id,
                Ip = ip,
                UserAgent = userAgent,
                FechaCreacion = DateTime.UtcNow,
                ExpiraEn = DateTime.UtcNow.AddDays(7)
            };

            await _sesionRepo.AddAsync(sesion, ct);
            await _sesionRepo.SaveChangesAsync(ct);

            var accessToken = _tokenService.GenerateJwtToken(usuario, null, null, 1);
            var refreshToken = await _refreshTokenService.GenerateRefreshTokenAsync(usuario.Id, sesion.Id, userAgent, ip, ct);

            return new AuthResult
            {
                Success = true,
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                ExpiraEn = DateTime.UtcNow.AddMinutes(60),
                UsuarioId = usuario.Id
            };
        }

        public async Task<AuthResult> RefreshTokenAsync(string refreshToken, string userAgent, string ip, CancellationToken ct)
        {
            var valido = await _refreshTokenService.ValidateAndUseRefreshTokenAsync(refreshToken, ct);
            if (!valido) return AuthResult.Fail("REFRESH_TOKEN_INVALIDO");

            string tokenHash = _hasher.HashPassword(refreshToken, out string salt);

            var tokenEntity = await _refreshRepo.FirstOrDefaultAsync(t => t.TokenHash == tokenHash, ct);
            if (tokenEntity == null) return AuthResult.Fail("TOKEN_NO_ENCONTRADO");

            var sesion = await _sesionRepo.GetByIdAsync(tokenEntity.SesionId, ct);
            if (sesion == null || sesion.ExpiraEn <= DateTime.UtcNow) return AuthResult.Fail("SESION_INVALIDA");

            var usuario = await _usuarioRepo.GetByIdAsync(sesion.UsuarioId, ct);
            if (usuario == null) return AuthResult.Fail("USUARIO_NO_ENCONTRADO");

            var accessToken = _tokenService.GenerateJwtToken(usuario, null, null, 1);
            var newRefreshToken = await _refreshTokenService.GenerateRefreshTokenAsync(usuario.Id, sesion.Id, userAgent, ip, ct);

            return new AuthResult
            {
                Success = true,
                AccessToken = accessToken,
                RefreshToken = newRefreshToken,
                ExpiraEn = DateTime.UtcNow.AddMinutes(60),
                UsuarioId = usuario.Id
            };
        }

        public async Task LogoutAsync(Guid usuarioId, string refreshToken, CancellationToken ct)
        {
            string tokenHash = _hasher.HashPassword(refreshToken, out string salt);

            var tokenEntity = await _refreshRepo.FirstOrDefaultAsync(t => t.TokenHash == tokenHash, ct);
            if (tokenEntity != null)
            {
                tokenEntity.RevocadoEn = DateTime.UtcNow;
                _refreshRepo.Update(tokenEntity);
                await _refreshRepo.SaveChangesAsync(ct);
            }
        }
    }
}
