using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.DTOs.Auth
{
    public interface ITokenService
    {
        string GenerateJwtToken(API_BASE.Domain.Entities.Usuario.Usuario usuario, List<string> roles, List<string> organismos, int politicasVersion);
        ClaimsPrincipal? ValidateJwtToken(string token);
    }
}
