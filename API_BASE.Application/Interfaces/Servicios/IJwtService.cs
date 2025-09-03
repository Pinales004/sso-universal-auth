using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.Interfaces.Servicios
{
    public interface IJwtService
    {
        string GenerateToken(Guid usuarioId, string email, IEnumerable<string> roles, IEnumerable<Claim>? extraClaims = null);
        ClaimsPrincipal? ValidateToken(string token);
        string GenerateRefreshToken();
    }
}
