using API_BASE.Domain.Base;
using API_BASE.Domain.Entities.Mantenimiento.UsuarioMan;
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
        public EstadoUsuario Estado { get; set; }

        public ICollection<UsuarioOrganizacion> Organizaciones { get; set; } = new List<UsuarioOrganizacion>();
        public ICollection<UsuarioRol> Roles { get; set; } = new List<UsuarioRol>();
        public ICollection<UsuarioPermiso> Permisos { get; set; } = new List<UsuarioPermiso>();

        public ICollection<PasswordHistory> PasswordHistories { get; set; } = new List<PasswordHistory>(); 
        public ICollection<LoginAttempt> LoginAttempts { get; set; } = new List<LoginAttempt>();           // Y esta si usas LoginAttempt

    }
}
