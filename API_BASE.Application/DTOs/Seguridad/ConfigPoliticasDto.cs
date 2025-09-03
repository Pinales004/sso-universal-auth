using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.DTOs.Seguridad
{
    public class ConfigPoliticasDto
    {
        public Guid Id { get; set; }
        public int Version { get; set; }
        public string? Descripcion { get; set; }
        public DateTime VigenteDesde { get; set; }
        public DateTime? VigenteHasta { get; set; }
    }
}
