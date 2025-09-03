using API_BASE.Application.DTOs.Notificaciones;
using API_BASE.Domain.Entities.Notificaciones;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.Mapping.Notificaciones
{
    public class NotificacionUsuarioProfile : Profile
    {
        public NotificacionUsuarioProfile()
        {
            CreateMap<NotificacionUsuario, NotificacionUsuarioDto>().ReverseMap();
        }
    }
}
