using API_BASE.Application.Interfaces;
using API_BASE.Application.Interfaces.Authorization;
using API_BASE.Application.Models.Authorization;
using API_BASE.Domain.Entities.Mantenimiento.UsuarioMan;
using API_BASE.Domain.Entities.Mantenimiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_BASE.Domain.Enums;

namespace API_BASE.Infrastructure.Servicios.Authorization
{
    public class PolicyEvaluatorService : IPolicyEvaluator
    {
        private readonly IRepository<UsuarioRol, Guid> _usuarioRolRepo;
        private readonly IRepository<UsuarioPermiso, Guid> _usuarioPermisoRepo;
        private readonly IRepository<RolPermiso, Guid> _rolPermisoRepo;

        public PolicyEvaluatorService(
            IRepository<UsuarioRol, Guid> usuarioRolRepo,
            IRepository<UsuarioPermiso, Guid> usuarioPermisoRepo,
            IRepository<RolPermiso, Guid> rolPermisoRepo)
        {
            _usuarioRolRepo = usuarioRolRepo;
            _usuarioPermisoRepo = usuarioPermisoRepo;
            _rolPermisoRepo = rolPermisoRepo;
        }

        public async Task<bool> HasPermissionAsync(Guid usuarioId, string permisoCodigo, string nodoCodigo, int? organismoIdExt, CancellationToken ct)
        {
            var result = await EvaluateAsync(usuarioId, permisoCodigo, nodoCodigo, organismoIdExt, ct);
            return result.Granted;
        }

        public async Task<PolicyEvaluationResult> EvaluateAsync(Guid usuarioId, string permisoCodigo, string nodoCodigo, int? organismoIdExt, CancellationToken ct)
        {
            // Permiso directo del usuario
            var usuarioPermiso = await _usuarioPermisoRepo.FirstOrDefaultAsync(
                up => up.UsuarioId == usuarioId &&
                      up.Permiso.Codigo == permisoCodigo &&
                      up.Nodo.Codigo == nodoCodigo,
                ct);

            if (usuarioPermiso != null)
            {
                return new PolicyEvaluationResult
                {
                    Granted = usuarioPermiso.Efecto == Efecto.ALLOW,
                    Efecto = usuarioPermiso.Efecto.ToString(),
                    Fuente = "USUARIO_OVERRIDE",
                    Detalle = "Permiso directo asignado al usuario"
                };
            }

            // Permiso por rol
            var roles = await _usuarioRolRepo.FindAsync(x => x.UsuarioId == usuarioId, ct);
            foreach (var rol in roles)
            {
                var rolPermiso = await _rolPermisoRepo.FirstOrDefaultAsync(
                    rp => rp.RolId == rol.RolId &&
                          rp.Permiso.Codigo == permisoCodigo &&
                          (rp.Nodo == null || rp.Nodo.Codigo == nodoCodigo),
                    ct);

                if (rolPermiso != null)
                {
                    return new PolicyEvaluationResult
                    {
                        Granted = rolPermiso.Efecto == Efecto.ALLOW,
                        Efecto = rolPermiso.Efecto.ToString(),
                        Fuente = "ROL",
                        Detalle = $"Permiso otorgado desde rol {rol.RolId}"
                    };
                }
            }

            // DENY por defecto
            return new PolicyEvaluationResult
            {
                Granted = false,
                Efecto = Efecto.DENY.ToString(),
                Fuente = "DEFAULT",
                Detalle = "Permiso no asignado"
            };
        }
    }
}
