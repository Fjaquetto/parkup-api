using AutoMapper;
using ParkUp.Application.Interfaces;
using ParkUp.Application.ViewModels;
using ParkUp.Domain.Interfaces;
using ParkUp.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkUp.Application.Services
{
    public class EmpresasAppService : IEmpresasAppService
    {
        private readonly IEmpresasRepository _empresasRepository;
        private readonly IMapper _mapper;
        public EmpresasAppService(IEmpresasRepository empresasRepository, IMapper mapper)
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
        public async Task<EmpresasViewModel> AtualizarEmpresa(EmpresasViewModel empresas)
        {
            return _mapper.Map<EmpresasViewModel>(await _empresasRepository.AtualizarEmpresa(_mapper.Map<Empresas>(empresas)));
        }

        public async Task<EmpresasViewModel> ObterEmpresaPorId(int id)
        {
            return _mapper.Map<EmpresasViewModel>(await _empresasRepository.ObterEmpresaPorId(id));
        }

        public async Task<bool> DesativarEmpresa(int id)
        {
            if (await _empresasRepository.DesativarEmpresa(id) is 0) return false;

            return true;
        }

        public async Task<bool> VerificaSeEmpresaExiste(EmpresasViewModel empresas)
        {
            var empresaEntity = await _empresasRepository.VerificaExistenciaEmpresa(_mapper.Map<Empresas>(empresas));
            return empresaEntity != null && empresaEntity.Id != empresas.Id;
        }

        public async Task<EmpresasViewModel> ExcluirEmpresa(EmpresasViewModel empresas)
        {
            return _mapper.Map<EmpresasViewModel>(await _empresasRepository.ExcluirEmpresa(_mapper.Map<Empresas>(empresas)));
        }

        #region "PRIVATE AREA"


        #endregion
    }
}
