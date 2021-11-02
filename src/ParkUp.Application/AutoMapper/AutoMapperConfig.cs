using AutoMapper;
using ParkUp.Application.ViewModels;
using ParkUp.Domain.Models;
using ParkUp.Domain.Models.Precos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkUp.Application.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Empresas, EmpresasViewModel>().ReverseMap();
            CreateMap<TipoPreco, TipoPrecoViewModel>().ReverseMap();
            CreateMap<PeriodoPreco, PeriodoPrecoViewModel>().ReverseMap();
        }
    }
}
