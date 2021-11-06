using ParkUp.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkUp.Application.Interfaces
{
    public interface ITipoPrecoAppService
    {
        Task<IEnumerable<TipoPrecoViewModel>> ListarTipoPrecos(int idEmpresa);
        Task<TipoPrecoViewModel> AdicionarTipoPreco(TipoPrecoViewModel tipoPrecos);
        Task<int> AtualizarTipoPreco(TipoPrecoViewModel tipoPrecos);
        Task<TipoPrecoViewModel> GetTipoPreco(int id);
    }
}
