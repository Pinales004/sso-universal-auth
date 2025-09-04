using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.Models.Auth
{
    public class AuthResult
    {
        public bool Success { get; set; }
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? ExpiraEn { get; set; }
        public bool RequiresMfa { get; set; }
        public string? ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }
        public Guid? UsuarioId { get; set; }
        public static AuthResult Fail(string mensaje) => new() { Success = false, ErrorMessage = mensaje };
    }
}
