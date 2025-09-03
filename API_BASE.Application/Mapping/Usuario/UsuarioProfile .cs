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
            //CreateMap<Usuario, UsuarioDto>()
            //    .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.Estado.ToString()));
            //CreateMap<UsuarioDto, Usuario>()
            //    .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => Enum.Parse<EstadoUsuario>(src.Estado)));
        }
    }
}
