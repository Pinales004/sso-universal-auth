using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.DTOs.Usuario
{
    public class PasswordHistoryDto
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public string PasswordHash { get; set; }
        public DateTime FechaCambio { get; set; }
    }
}
