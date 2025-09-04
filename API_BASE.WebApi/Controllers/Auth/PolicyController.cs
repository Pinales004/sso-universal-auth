using API_BASE.Application.Interfaces.Authorization;
using API_BASE.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace API_BASE.WebApi.Controllers.Auth
{

        [ApiController]
        [Route("api/[controller]")]
        public class PolicyController : ControllerBase
        {
            private readonly IPolicyEvaluator _policyEvaluator;

            public PolicyController(IPolicyEvaluator policyEvaluator)
            {
                _policyEvaluator = policyEvaluator;
            }

            [HttpGet("has-permission")]
            public async Task<ActionResult<ApiResponse<bool>>> HasPermission(Guid usuarioId, string permiso, string nodo, int? organismoId, CancellationToken ct)
            {
                var granted = await _policyEvaluator.HasPermissionAsync(usuarioId, permiso, nodo, organismoId, ct);
                return Ok(ApiResponse<bool>.Ok(granted));
            }
        }
}
