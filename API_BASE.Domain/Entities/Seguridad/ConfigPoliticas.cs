using API_BASE.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Domain.Entities.Seguridad
{

    //Versionado de políticas para cache-busting y claims en JWT.
    public class ConfigPoliticas : AuditableEntity
    {
        public int Version { get; set; }
        public string? Descripcion { get; set; }
        public DateTime VigenteDesde { get; set; }
        public DateTime? VigenteHasta { get; set; }
    }
}
