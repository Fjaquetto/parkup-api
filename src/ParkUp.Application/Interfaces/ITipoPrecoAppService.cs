using ParkUp.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkUp.Application.Interfaces
{
    public interface ITipoPrecoAppService
    {
        Task<IEnumerable<TipoPrecoViewModel>> ListarTipoPrecos(int idEmpresa);
        Task AdicionarTipoPreco(TipoPrecoViewModel tipoPrecos);
        Task<int> AtualizarTipoPreco(TipoPrecoViewModel tipoPrecos);
    }
}
