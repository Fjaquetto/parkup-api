using ParkUp.Application.ViewModels;
using ParkUp.Domain.Models.RequestModels.TipoPreco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkUp.Application.Interfaces
{
    public interface ITipoPrecoAppService
    {
        Task<IEnumerable<TipoPrecoViewModel>> ListarTipoPrecos(int idEmpresa);
        Task<TipoPrecoViewModel> AdicionarTipoPreco(TipoPrecoViewModel tipoPrecos);
        Task<int> AtualizarTipoPreco(TipoPrecoModelRequest tipoPrecos);
        Task<TipoPrecoViewModel> GetTipoPreco(int id);
    }
}
