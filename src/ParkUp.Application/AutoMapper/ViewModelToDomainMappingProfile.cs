﻿using AutoMapper;
using ParkUp.Application.ViewModels;
using ParkUp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkUp.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<EmpresasViewModel, Empresas>()
                .ForMember(x => x.DataCadastro, opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(x => x.FlgAtivo, opt => opt.MapFrom(x => true));
        }
    }
}