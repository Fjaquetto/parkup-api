using AutoMapper;
using ParkUp.Application.ViewModels;
using ParkUp.Domain.Models;
using ParkUp.Domain.Models.Precos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkUp.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Empresas, EmpresasViewModel>();
            CreateMap<TipoPreco, TipoPrecoViewModel>();
            CreateMap<PeriodoPreco, PeriodoPrecoViewModel>();
            CreateMap<Patio, PatioViewModel>();
            CreateMap<PatioCaixa, PatioCaixaViewModel>();
        }
    }
}
