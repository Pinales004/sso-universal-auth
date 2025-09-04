using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.Interfaces.Mfa
{
    public interface ITotpService
    {
        string GenerateSecret();  // Genera el secreto único para el usuario
        string GenerateQrCode(string issuer, string usuarioId, string secret);  // Código QR en base64
        bool ValidateCode(string secret, string code);  // Valida el código ingresado
        List<string> GenerateRecoveryCodes();  // Genera códigos de recuperación
    }
}
