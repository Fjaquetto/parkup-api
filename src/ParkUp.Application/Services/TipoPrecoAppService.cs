using AutoMapper;
using ParkUp.Application.Interfaces;
using ParkUp.Application.ViewModels;
using ParkUp.Domain.Interfaces;
using ParkUp.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkUp.Application.Services
{
    public class TipoPrecoAppService : ITipoPrecoAppService
    {
        private readonly ITipoPrecoRepository _tipoPrecoRepository;
        private readonly IPeriodoPrecoAppService _periodoPrecoAppService;
        private readonly IMapper _mapper;
        public TipoPrecoAppService(ITipoPrecoRepository tipPrecoRepository, 
            IMapper mapper,
            IPeriodoPrecoAppService periodoPrecoAppService)
        {
            _tipoPrecoRepository = tipPrecoRepository;
            _mapper = mapper;
            _periodoPrecoAppService = periodoPrecoAppService;
        }       

        public async Task<IEnumerable<TipoPrecoViewModel>> ListarTipoPrecos(int idEmpresa)
        {
            return _mapper.Map<IEnumerable<TipoPrecoViewModel>>(await _tipoPrecoRepository.ListarPrecos(idEmpresa));
        }

        public async Task<TipoPrecoViewModel> AdicionarTipoPreco(TipoPrecoViewModel tipoPrecos)
        {
            return _mapper.Map<TipoPrecoViewModel>(await _tipoPrecoRepository.AdicionarTipoPreco(_mapper.Map<TipoPreco>(tipoPrecos)));          
        }

        public async Task<int> AtualizarTipoPreco(TipoPrecoViewModel tipoPrecos)
        {
            return await _tipoPrecoRepository.AtualizarTipoPreco(_mapper.Map<TipoPreco>(tipoPrecos));
        }

        public async Task<TipoPrecoViewModel> GetTipoPreco(int idTipoPreco)
        {
            return _mapper.Map<TipoPrecoViewModel>(await _tipoPrecoRepository.RecuperarTipoPreco(idTipoPreco));
        }
    }
}
