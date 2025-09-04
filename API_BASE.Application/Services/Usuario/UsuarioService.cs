using API_BASE.Application.DTOs.Usuario;
using API_BASE.Application.Interfaces;
using API_BASE.Application.Interfaces.Usuario;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.Services.Usuario
{
    public class UsuarioService : IUsuario
    {
        private readonly IRepository<API_BASE.Domain.Entities.Usuario.Usuario, Guid> _repository;

        public UsuarioService(IRepository<API_BASE.Domain.Entities.Usuario.Usuario, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<bool> EmailExistsAsync(string email, CancellationToken ct = default)
        {
            return await _repository.AnyAsync(u => u.Email == email, ct);
        }

        public async Task CambiarPasswordAsync(Guid usuarioId, string nuevaPassword, CancellationToken ct = default)
        {
            var usuario = await _repository.GetByIdAsync(usuarioId, ct);
            if (usuario == null)
                throw new Exception("Usuario no encontrado");
            usuario.PasswordHash = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(nuevaPassword));
            usuario.PasswordUpdatedAt = DateTime.UtcNow;
            usuario.MustChangePassword = false;
            _repository.Update(usuario);
            await _repository.SaveChangesAsync(ct);
        }
    }
}