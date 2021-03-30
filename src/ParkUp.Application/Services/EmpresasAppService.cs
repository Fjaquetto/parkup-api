using AutoMapper;
using ParkUp.Application.Interfaces;
using ParkUp.Application.ViewModels;
using ParkUp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
