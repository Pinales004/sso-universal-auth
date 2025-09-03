using API_BASE.Application.DTOs.Aplicaciones;
using API_BASE.Domain.Entities.Aplicacion;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.Mapping.Aplicaciones
{
    public class AplicacionProfile : Profile
    {
        public AplicacionProfile()
        {
            CreateMap<Aplicacion, AplicacionDto>().ReverseMap();
        }
    }
}
