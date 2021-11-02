using AutoMapper;
using ParkUp.Application.Interfaces;
using ParkUp.Application.ViewModels;
using ParkUp.Domain.Interfaces;
using ParkUp.Domain.Models.Precos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkUp.Application.Services
{
    public class PeriodoPrecoAppService : IPeriodoPrecoAppService
    {

        private readonly IPeriodoPrecoRepository _repository;
        private readonly IMapper _mapper;
        public PeriodoPrecoAppService(IPeriodoPrecoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PeriodoPrecoViewModel> AdicionarPrecoPeriodo(PeriodoPrecoViewModel periodoPreco)
        {
            return _mapper.Map<PeriodoPrecoViewModel>(await _repository.AdicionarPeriodoPreco(_mapper.Map<PeriodoPreco>(periodoPreco)));
        }

        public Task<int> AtualizarPeriodoPreco(PeriodoPrecoViewModel periodoPreco)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PeriodoPrecoViewModel>> ListarTodosPrecosByIdTipoPreco(int idTipoPreco)
        {
            return _mapper.Map<List<PeriodoPrecoViewModel>>(await _repository.ListarPeriodoPrecosByIdTipoPreco(idTipoPreco));
        }
    }
}
