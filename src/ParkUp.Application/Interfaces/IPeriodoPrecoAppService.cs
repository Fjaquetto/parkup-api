using ParkUp.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkUp.Application.Interfaces
{
    public interface IPeriodoPrecoAppService
    {
        Task<IEnumerable<PeriodoPrecoViewModel>> ListarTodosPrecosByIdTipoPreco(int idTipoPreco);
        Task<PeriodoPrecoViewModel> AdicionarPrecoPeriodo(PeriodoPrecoViewModel periodoPreco);
        Task<int> AtualizarPeriodoPreco(PeriodoPrecoViewModel periodoPreco);
    }
}
