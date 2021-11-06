using ParkUp.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkUp.Application.Interfaces
{
    public interface IPatioAppService
    {
        Task<IEnumerable<PatioViewModel>> GetRegistrosPatio();

        Task<int> GetRegistrosPatioById(int idPatio);

        Task<PatioViewModel> PostRegistroPatio(PatioViewModel registroPatio);
        Task<int> PutRegistroPatio(PatioViewModel registroPatio);
        Task<PatioViewModel> PatchSaidaVeiculo(PatioViewModel registroPatio);
        Task<IEnumerable<PatioCaixaViewModel>> GetCaixaSaldoByPeriodo(int idEmpresa, DateTime periodo);

    }
}
