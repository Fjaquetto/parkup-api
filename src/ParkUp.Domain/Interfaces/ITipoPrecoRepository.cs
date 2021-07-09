using ParkUp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkUp.Domain.Interfaces
{
    public interface ITipoPrecoRepository : IRepository<TipoPreco>
    {
        Task<IEnumerable<TipoPreco>> ListarPrecos(int IdEmpresa);
        Task<TipoPreco> AdicionarTipoPreco(TipoPreco tipoPreco);
        Task<int> AtualizarTipoPreco(TipoPreco tipoPreco);
    }
}
