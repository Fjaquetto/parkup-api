using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkUp.Domain.Interfaces
{
    public interface ITipoPrecoQuery : IQueryBase
    {
        Task<string> ListarPrecos();
        Task<string> AdicionarTipoPreco();
        Task<string> AtualizarTipoPreco();
        Task<string> RecuperarTipoPreco();
    }
}
