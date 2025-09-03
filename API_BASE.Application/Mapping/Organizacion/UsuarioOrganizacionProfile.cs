using API_BASE.Application.DTOs.Organizacion;
using API_BASE.Domain.Entities.Usuario;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.Mapping.Organizacion
{
    public class UsuarioOrganizacionProfile : Profile
    {
        public UsuarioOrganizacionProfile()
        {
            CreateMap<UsuarioOrganizacion, UsuarioOrganizacionDto>().ReverseMap();
        }
    }
}
