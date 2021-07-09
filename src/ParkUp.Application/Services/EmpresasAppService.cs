using AutoMapper;
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
    public class EmpresasAppService : IEmpresasAppService
    {
        private readonly ITipoPrecoRepository _empresasRepository;
        private readonly IMapper _mapper;
        public EmpresasAppService(ITipoPrecoRepository empresasRepository, IMapper mapper)
        {
            _empresasRepository = empresasRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmpresasViewModel>> ListarEmpresas()
        {
            return _mapper.Map<IEnumerable<EmpresasViewModel>>(await _empresasRepository.ListarEmpresas());
        }

        public async Task<EmpresasViewModel> AdicionarEmpresa(EmpresasViewModel empresas)
        {
            return _mapper.Map<EmpresasViewModel>(await _empresasRepository.AdicionarEmpresa(_mapper.Map<Empresas>(empresas)));
        }
        public async Task<int> AtualizarEmpresa(EmpresasViewModel empresas)
        {
            return await _empresasRepository.AtualizarEmpresa(_mapper.Map<Empresas>(empresas));
        }
    }
}
