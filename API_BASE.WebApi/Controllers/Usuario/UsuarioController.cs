using API_BASE.Application.DTOs.Usuario;
using API_BASE.Application.Interfaces;
using API_BASE.Application.Interfaces.Usuario;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_BASE.WebApi.Controllers.Usuario
{

    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : BaseController<UsuarioDto, UsuarioCreateDto, UsuarioUpdateDto, API_BASE.Domain.Entities.Usuario.Usuario, Guid>
    {
        private readonly IUsuario _usuarioService;

        public UsuarioController(
            IRepository<API_BASE.Domain.Entities.Usuario.Usuario, Guid> repository,
            IMapper mapper,
            IUsuario usuarioService
        ) : base(repository, mapper)
        {
            _usuarioService = usuarioService;
        }

        protected override Guid GetId(UsuarioDto dto) => dto.Id;

        [HttpGet("exists/email")]
        public async Task<ActionResult<bool>> EmailExists(string email, CancellationToken ct)
            => Ok(await _usuarioService.EmailExistsAsync(email, ct));

        [HttpPost("{id}/cambiar-password")]
        public async Task<ActionResult> CambiarPassword(Guid id, [FromBody] string nuevaPassword, CancellationToken ct)
        {
            await _usuarioService.CambiarPasswordAsync(id, nuevaPassword, ct);
            return NoContent();
        }
    }
}
