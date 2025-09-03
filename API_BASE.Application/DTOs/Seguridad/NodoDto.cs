using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.DTOs.Seguridad
{
    public class NodoDto
    {
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public string Tipo { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int? Orden { get; set; }
        public bool Activo { get; set; }
    }
}
