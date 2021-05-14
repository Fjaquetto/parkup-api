using ParkUp.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkUp.Application.Interfaces
{
    public interface IEmpresasAppService
    {
        Task<IEnumerable<EmpresasViewModel>> ListarEmpresas();
        Task<EmpresasViewModel> AdicionarEmpresa(EmpresasViewModel empresas);
        Task<int> AtualizarEmpresa(EmpresasViewModel empresas);
        Task<EmpresasViewModel> ObterEmpresaPorId(int id);
        Task<bool> DesativarEmpresa(int id);
    }
}
