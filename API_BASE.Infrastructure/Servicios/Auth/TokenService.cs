using API_BASE.Application.DTOs.Auth;
using API_BASE.Domain.Entities.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Infrastructure.Servicios.Auth
{
    public class TokenService : ITokenService
    {
        public string GenerateJwtToken(Usuario usuario, List<string> roles, List<string> organismos, int politicasVersion)
        {
            // TODO: Implementar generación de JWT usando System.IdentityModel.Tokens.Jwt
            throw new NotImplementedException();
        }

        public ClaimsPrincipal? ValidateJwtToken(string token)
        {
            // TODO: Implementar validación del JWT
            throw new NotImplementedException();
        }
    }
}