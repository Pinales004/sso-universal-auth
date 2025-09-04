using API_BASE.Domain.Base;
using API_BASE.Domain.Entities.Mantenimiento.UsuarioMan;
using API_BASE.Domain.Entities.Seguridad;
using API_BASE.Domain.Entities.Usuario;
using API_BASE.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Domain.Entities.Organismo
{
    public class Organismo : AuditableEntity
    {
        // Propiedades básicas
        public string Nombre { get; set; } = string.Empty;
        public TipoOrganizacion Tipo { get; set; }
        public Guid? ParentId { get; set; }
        public string? Codigo { get; set; }

        // Relaciones jerárquicas
        public Organismo? Padre { get; set; }
        public ICollection<Organismo> Hijos { get; set; } = new List<Organismo>();

        // Relaciones con usuarios
        public ICollection<UsuarioOrganizacion> UsuarioOrganizaciones { get; set; } = new List<UsuarioOrganizacion>();

        // Opcionales: relaciones de auditoría o permisos globales si se necesitan
        public ICollection<UsuarioRol> UsuarioRoles { get; set; } = new List<UsuarioRol>();
        public ICollection<Auditoria> Auditorias { get; set; } = new List<Auditoria>();
    }
}

