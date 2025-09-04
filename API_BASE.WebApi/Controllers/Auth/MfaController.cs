using API_BASE.Application.DTOs;
using API_BASE.Application.Interfaces.Mfa;
using API_BASE.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace API_BASE.WebApi.Controllers.Auth
{

        [ApiController]
        [Route("api/[controller]")]
        public class MfaController : ControllerBase
        {
            private readonly IMfaService _mfaService;

            public MfaController(IMfaService mfaService)
            {
                _mfaService = mfaService;
            }

            [HttpPost("activar/{usuarioId}")]
            public async Task<ActionResult<ApiResponse<MfaSetupResult>>> ActivarMfa(Guid usuarioId, CancellationToken ct)
            {
                var result = await _mfaService.ActivarMfaAsync(usuarioId, ct);
                return Ok(ApiResponse<MfaSetupResult>.Ok(result));
            }

            [HttpPost("validar")]
            public async Task<ActionResult<ApiResponse<bool>>> ValidarMfa([FromBody] ValidarMfaRequest request, CancellationToken ct)
            {
                var valid = await _mfaService.ValidarMfaAsync(request.UsuarioId, request.Code, ct);
                return Ok(ApiResponse<bool>.Ok(valid));
            }

            [HttpPost("desactivar/{usuarioId}")]
            public async Task<ActionResult<ApiResponse<bool>>> DesactivarMfa(Guid usuarioId, CancellationToken ct)
            {
                await _mfaService.DesactivarMfaAsync(usuarioId, ct);
                return Ok(ApiResponse<bool>.Ok(true));
            }

            [HttpPost("recovery/generar/{usuarioId}")]
            public async Task<ActionResult<ApiResponse<List<string>>>> GenerarRecovery(Guid usuarioId, CancellationToken ct)
            {
                var codes = await _mfaService.GenerarRecoveryCodesAsync(usuarioId, ct);
                return Ok(ApiResponse<List<string>>.Ok(codes));
            }

            [HttpPost("recovery/usar")]
            public async Task<ActionResult<ApiResponse<bool>>> UsarRecovery([FromBody] UsarRecoveryRequest request, CancellationToken ct)
            {
                var result = await _mfaService.UsarRecoveryCodeAsync(request.UsuarioId, request.Code, ct);
                return Ok(ApiResponse<bool>.Ok(result));
            }

            public class ValidarMfaRequest
            {
                public Guid UsuarioId { get; set; }
                public string Code { get; set; } = string.Empty;
            }

            public class UsarRecoveryRequest
            {
                public Guid UsuarioId { get; set; }
                public string Code { get; set; } = string.Empty;
            }
        }
}
