using API_BASE.Application.DTOs.Aplicaciones;
using API_BASE.Domain.Entities.Mantenimiento.Aplicacion;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.Mapping.Aplicaciones
{
    public class AplicacionPermisoProfile : Profile
    {
        public AplicacionPermisoProfile()
        {
            CreateMap<AplicacionPermiso, AplicacionPermisoDto>().ReverseMap();
        }
    }
}
