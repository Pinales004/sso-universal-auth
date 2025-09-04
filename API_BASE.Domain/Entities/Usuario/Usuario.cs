using API_BASE.Domain.Base;
using API_BASE.Domain.Entities.Mantenimiento.UsuarioMan;
using API_BASE.Domain.Entities.Seguridad;
using API_BASE.Domain.Entities.Usuario.Solicitud;
using API_BASE.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Domain.Entities.Usuario
{
    public class Usuario : AuditableEntity
    {
        public string Email { get; set; }
        public string? Username { get; set; }
        public string? Telefono { get; set; }
        public string? PasswordHash { get; set; }
        public string? PasswordSalt { get; set; }
        public DateTime? PasswordUpdatedAt { get; set; }
        public bool MustChangePassword { get; set; }
        public bool EsAdminGlobal { get; set; }
        public bool MfaEnabled { get; set; } = false;
        public EstadoUsuario Estado { get; set; }

        // -----------------------------
        // Relaciones / Propiedades de navegación
        // -----------------------------

        // Roles asignados al usuario
        public ICollection<UsuarioRol> Roles { get; set; } = new List<UsuarioRol>();

        // Permisos asignados directamente al usuario
        public ICollection<UsuarioPermiso> Permisos { get; set; } = new List<UsuarioPermiso>();

        // Organismos a los que pertenece
        public ICollection<UsuarioOrganizacion> Organizaciones { get; set; } = new List<UsuarioOrganizacion>();

        // Sesiones activas / históricas
        public ICollection<Sesion> Sesiones { get; set; } = new List<Sesion>();

        // Refresh tokens asociados
        public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

        // Historial de contraseñas
        public ICollection<PasswordHistory> PasswordHistories { get; set; } = new List<PasswordHistory>();

        // Intentos de login (para auditoría / bloqueo)
        public ICollection<LoginAttempt> LoginAttempts { get; set; } = new List<LoginAttempt>();

        // MFA TOTP
        public ICollection<MfaTotp> Totps { get; set; } = new List<MfaTotp>();

        // MFA Recovery codes
        public ICollection<MfaRecoveryCode> MfaRecoveryCodes { get; set; } = new List<MfaRecoveryCode>();

        // Auditorías realizadas por el usuario
        public ICollection<Auditoria> Auditorias { get; set; } = new List<Auditoria>();

        // Solicitudes realizadas (alta, cambio, rol, etc.)
        public ICollection<SolicitudUsuario> SolicitudesUsuario { get; set; } = new List<SolicitudUsuario>();

        // Emails pendientes de verificación
        public ICollection<EmailVerification> EmailVerifications { get; set; } = new List<EmailVerification>();

        // Reset de contraseñas
        public ICollection<PasswordResetRequest> PasswordResetRequests { get; set; } = new List<PasswordResetRequest>();

    }
}
