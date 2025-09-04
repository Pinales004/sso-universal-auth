using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.DTOs
{
    public class MfaSetupResult
    {
        /// <summary>
        /// Código QR en Base64 que el usuario puede escanear con Google Authenticator o similar.
        /// </summary>
        public string QrCodeImageBase64 { get; set; } = string.Empty;

        /// <summary>
        /// Clave manual que el usuario puede ingresar si no puede escanear el QR.
        /// </summary>
        public string ManualEntryKey { get; set; } = string.Empty;

        /// <summary>
        /// Indica si la activación fue exitosa.
        /// </summary>
        public bool Success { get; set; } = true;

        /// <summary>
        /// Mensaje adicional o error.
        /// </summary>
        public string? Message { get; set; }
    }
}
