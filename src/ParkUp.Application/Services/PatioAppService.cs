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
    public class PatioAppService: IPatioAppService
    {
        private readonly IPatioRepository _patioRepository;
        private readonly IMapper _automapper;

        public PatioAppService(IPatioRepository patioRepository, IMapper automapper)
        {
            _patioRepository = patioRepository;
            _automapper = automapper;
        }

        public async Task<IEnumerable<PatioViewModel>> GetRegistrosPatio()
        {
            return _automapper.Map<IEnumerable<PatioViewModel>>(await _patioRepository.GetRegistrosPatio());
        }

        public async Task<int> GetRegistrosPatioById(int idPatio)
        {
            return await _patioRepository.GetRegistrosPatioById(idPatio);
        }

        public async Task<PatioViewModel> PostRegistroPatio(PatioViewModel registroPatio)
        {
            return _automapper.Map<PatioViewModel>(await _patioRepository.PostRegistroPatio(_automapper.Map<Patio>(registroPatio)));
        }

        public async Task<int> PutRegistroPatio(PatioViewModel registroPatio)
        {
            return await _patioRepository.PutRegistroPatio(_automapper.Map<Patio>(registroPatio));
        }


    }
}
