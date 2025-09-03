using API_BASE.Application.DTOs.Usuario;
using API_BASE.Domain.Entities.Usuario;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.Mapping.Usuario
{
    public class PasswordHistoryProfile : Profile
    {
        public PasswordHistoryProfile()
        {
            CreateMap<PasswordHistory, PasswordHistoryDto>().ReverseMap();
        }
    }
}
