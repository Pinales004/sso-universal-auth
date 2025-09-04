using API_BASE.Application.Models.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.Interfaces.Authorization
{
    public interface IPolicyEvaluator
    {
        /// <summary>
        /// ¿El usuario tiene el permiso en el nodo/organismo indicado?
        /// </summary>
        Task<bool> HasPermissionAsync(Guid usuarioId, string permisoCodigo, string nodoCodigo, int? organismoIdExt, CancellationToken ct);

        /// <summary>
        /// Evaluación detallada (ALLOW/DENY, fuente, motivo, etc).
        /// </summary>
        Task<PolicyEvaluationResult> EvaluateAsync(Guid usuarioId, string permisoCodigo, string nodoCodigo, int? organismoIdExt, CancellationToken ct);
    }
}