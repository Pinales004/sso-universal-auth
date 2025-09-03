using API_BASE.Application.DTOs.Seguridad;
using API_BASE.Domain.Entities.Seguridad;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.Mapping.Seguridad
{
    public class NodoProfile : Profile
    {
        public NodoProfile()
        {
            CreateMap<Nodo, NodoDto>().ReverseMap();
        }
    }
}
