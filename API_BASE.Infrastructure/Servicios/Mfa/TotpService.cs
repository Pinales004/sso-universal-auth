using API_BASE.Application.Interfaces.Mfa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OtpNet;
namespace API_BASE.Infrastructure.Servicios.Mfa
{
    public class TotpService : ITotpService
    {
        public string GenerateSecret()
        {
            var key = KeyGeneration.GenerateRandomKey(20); // 160 bits
            return Base32Encoding.ToString(key);
        }

        public string GenerateQrCode(string issuer, string usuarioId, string secret)
        {
            // Para Google Authenticator
            string totpUri = $"otpauth://totp/{issuer}:{usuarioId}?secret={secret}&issuer={issuer}&digits=6";
            // Aquí podrías generar un QRCode en base64 usando librería externa
            return totpUri;
        }

        public bool ValidateCode(string secret, string code)
        {
            var key = Base32Encoding.ToBytes(secret);
            var totp = new Totp(key);
            return totp.VerifyTotp(code, out long _, VerificationWindow.RfcSpecifiedNetworkDelay);
        }

        public List<string> GenerateRecoveryCodes()
        {
            var codes = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                codes.Add(Guid.NewGuid().ToString("N").Substring(0, 8));
            }
            return codes;
        }
    }
}