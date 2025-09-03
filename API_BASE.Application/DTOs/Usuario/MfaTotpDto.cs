using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.DTOs.Usuario
{
    public class MfaTotpDto
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public string Secret { get; set; }
        public bool Habilitado { get; set; }
        public DateTime? DeshabilitadoEn { get; set; }
    }
}
