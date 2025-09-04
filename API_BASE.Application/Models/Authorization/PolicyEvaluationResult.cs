using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.Models.Authorization
{
    public class PolicyEvaluationResult
    {
        /// <summary>
        /// Indica si la acción es permitida (true = ALLOW, false = DENY).
        /// </summary>
        public bool Granted { get; set; }

        /// <summary>
        /// Resultado efectivo de la evaluación ("ALLOW" o "DENY").
        /// </summary>
        public string Efecto { get; set; } = "DENY";

        /// <summary>
        /// Fuente de la autorización (ejemplo: "ROL", "USUARIO_OVERRIDE", "HERENCIA", "GLOBAL").
        /// </summary>
        public string? Fuente { get; set; }

        /// <summary>
        /// Detalle explicativo del resultado (precedencia, motivo de DENY, etc).
        /// </summary>
        public string? Detalle { get; set; }

        /// <summary>
        /// Id del rol involucrado (si aplica).
        /// </summary>
        public int? RolId { get; set; }

        /// <summary>
        /// Id del permiso evaluado.
        /// </summary>
        public int? PermisoId { get; set; }

        /// <summary>
        /// Id del nodo funcional evaluado.
        /// </summary>
        public int? NodoId { get; set; }

        /// <summary>
        /// Id del organismo COEDOM (si aplica).
        /// </summary>
        public int? OrganismoIdExt { get; set; }

        /// <summary>
        /// Rango de vigencia del permiso evaluado (desde).
        /// </summary>
        public DateTime? VigenteDesde { get; set; }

        /// <summary>
        /// Rango de vigencia del permiso evaluado (hasta).
        /// </summary>
        public DateTime? VigenteHasta { get; set; }

        /// <summary>
        /// Pasos detallados de la evaluación (útil para debug/auditoría).
        /// </summary>
        public List<string>? EvaluacionPasoAPaso { get; set; }
    }
}
