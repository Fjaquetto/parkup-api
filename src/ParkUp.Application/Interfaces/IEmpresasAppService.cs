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
    }
}
