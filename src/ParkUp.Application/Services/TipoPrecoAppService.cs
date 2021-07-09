﻿using AutoMapper;
using ParkUp.Application.Interfaces;
using ParkUp.Application.ViewModels;
using ParkUp.Domain.Interfaces;
using ParkUp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkUp.Application.Services
{
    public class TipoPrecoAppService : ITipoPrecoAppService
    {
        private readonly ITipoPrecoRepository _tipoPrecoRepository;
        private readonly IMapper _mapper;
        public TipoPrecoAppService(ITipoPrecoRepository tipPrecoRepository, IMapper mapper)
        {
            _tipoPrecoRepository = tipPrecoRepository;
            _mapper = mapper;
        }       

        public async Task<IEnumerable<TipoPrecoViewModel>> ListarTipoPrecos(int idEmpresa)
        {
            return _mapper.Map<IEnumerable<TipoPrecoViewModel>>(await _tipoPrecoRepository.ListarPrecos(idEmpresa));
        }

        public Task AdicionarTipoPreco(TipoPrecoViewModel tipoPrecos)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AtualizarTipoPreco(TipoPrecoViewModel tipoPrecos)
        {
            return await _tipoPrecoRepository.AtualizarTipoPreco(_mapper.Map<TipoPreco>(tipoPrecos));
        }
    }
}
