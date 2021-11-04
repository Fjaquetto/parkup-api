using AutoMapper;
using ParkUp.Application.ViewModels;
using ParkUp.Domain.Models;
using ParkUp.Domain.Models.Precos;
using ParkUp.Domain.Models.RequestModels.TipoPreco;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkUp.Application.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<TipoPreco, TipoPrecoViewModel>();
            CreateMap<PeriodoPreco, PeriodoPrecoViewModel>().ReverseMap();
            CreateMap<Patio, PatioViewModel>().ReverseMap();

            CreateMap<TipoPrecoModelRequest, TipoPreco>()
                .ForMember(dest => dest.DataCadastro, source => source.MapFrom(s => DateTime.Now))
                .ForMember(dest => dest.DataUltimaAlteracao, source => source.MapFrom(s => DateTime.Now));
                
            #region "Empresas"
            CreateMap<Empresas, EmpresasViewModel>();

            CreateMap<EmpresasViewModel, Empresas>()
                .ForMember(x => x.DataCadastro, opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(x => x.FlgAtivo, opt => opt.MapFrom(x => true));
            #endregion
        }
    }
}
