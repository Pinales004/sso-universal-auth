using API_BASE.Application.DTOs.Usuario;
using API_BASE.Domain.Enums;
using AutoMapper;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.Mapping.Usuario
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<API_BASE.Domain.Entities.Usuario.Usuario, UsuarioDto>()
               .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado.ToString()));

            CreateMap<UsuarioDto, API_BASE.Domain.Entities.Usuario.Usuario>()
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => Enum.Parse<EstadoUsuario>(src.Estado.ToString())));

            CreateMap<UsuarioCreateDto, API_BASE.Domain.Entities.Usuario.Usuario>();
            CreateMap<UsuarioUpdateDto, API_BASE.Domain.Entities.Usuario.Usuario>();

        }
    }
 }

