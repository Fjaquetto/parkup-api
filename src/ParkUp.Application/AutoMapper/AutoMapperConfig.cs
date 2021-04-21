﻿using AutoMapper;
using ParkUp.Application.ViewModels;
using ParkUp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkUp.Application.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            #region "Empresas"
            CreateMap<Empresas, EmpresasViewModel>();

            CreateMap<EmpresasViewModel, Empresas>()
                .ForMember(x => x.DataCadastro, opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(x => x.FlgAtivo, opt => opt.MapFrom(x => true));
            #endregion
        }
    }
}
