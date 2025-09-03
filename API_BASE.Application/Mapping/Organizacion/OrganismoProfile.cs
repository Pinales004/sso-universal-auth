using API_BASE.Application.DTOs.Organizacion;
using API_BASE.Domain.Entities.Organismo;
using API_BASE.Domain.Enums;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.Mapping.Organizacion
{
    public class OrganismoProfile : Profile
    {
        public OrganismoProfile()
        {
            CreateMap<Organismo, OrganismoDto>()
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo.ToString()))
                .ReverseMap()
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => Enum.Parse<TipoOrganizacion>(src.Tipo)));
        }
    }
}
