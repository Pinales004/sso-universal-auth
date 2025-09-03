using API_BASE.Application.DTOs.Usuario.Solicitud;
using API_BASE.Domain.Entities.Usuario.Solicitud;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.Mapping.Usuario.Solicitud
{
    public class SolicitudUsuarioProfile : Profile
    {
        public SolicitudUsuarioProfile()
        {
            CreateMap<SolicitudUsuario, SolicitudUsuarioDto>().ReverseMap();
        }
    }
}
