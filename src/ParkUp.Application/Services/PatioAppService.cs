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
    public class PatioAppService: IPatioAppService
    {
        private readonly IPatioRepository _patioRepository;
        private readonly IMapper _automapper;

        public PatioAppService(IPatioRepository patioRepository, IMapper automapper)
        {
            _patioRepository = patioRepository;
            _automapper = automapper;
        }

        public async Task<IEnumerable<PatioViewModel>> ListarRegistroPatio()
        {
            return _automapper.Map<IEnumerable<PatioViewModel>>(await _patioRepository.ListarRegistroPatio());
        }
    }
}
