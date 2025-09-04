using API_BASE.Application.Interfaces.Auth;
using API_BASE.Application.Models.Auth;
using API_BASE.Infrastructure.Servicios;
using API_BASE.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace API_BASE.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<ApiResponse<AuthResult>>> Login([FromBody] LoginRequest request, CancellationToken ct)
        {
            var result = await _authService.LoginAsync(
                request.Email,
                request.Password,
                request.MfaCode,
                request.UserAgent,
                request.Ip,
                ct
            );

            if (!result.Success)
                return BadRequest(ApiResponse<AuthResult>.Fail(result.ErrorMessage ?? "Login fallido"));

            return Ok(ApiResponse<AuthResult>.Ok(result));
        }

        [HttpPost("refresh")]
        public async Task<ActionResult<ApiResponse<AuthResult>>> Refresh([FromBody] RefreshTokenRequest request, CancellationToken ct)
        {
            var result = await _authService.RefreshTokenAsync(
                request.RefreshToken,
                request.UserAgent,
                request.Ip,
                ct
            );

            if (!result.Success)
                return BadRequest(ApiResponse<AuthResult>.Fail(result.ErrorMessage ?? "Refresh fallido"));

            return Ok(ApiResponse<AuthResult>.Ok(result));
        }

        [HttpPost("logout")]
        public async Task<ActionResult<ApiResponse<bool>>> Logout([FromBody] LogoutRequest request, CancellationToken ct)
        {
            await _authService.LogoutAsync(request.UsuarioId, request.RefreshToken, ct);
            return Ok(ApiResponse<bool>.Ok(true));
        }
    }

    // DTOs específicos para el controlador
    public class LoginRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? MfaCode { get; set; }
        public string UserAgent { get; set; } = string.Empty;
        public string Ip { get; set; } = string.Empty;
    }

    public class RefreshTokenRequest
    {
        public string RefreshToken { get; set; } = string.Empty;
        public string UserAgent { get; set; } = string.Empty;
        public string Ip { get; set; } = string.Empty;
    }

    public class LogoutRequest
    {
        public Guid UsuarioId { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
    }
}
