using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkUp.Domain.Interfaces
{
    public interface ÌPeriodoPrecoQuery : IQueryBase
    {
        Task<string> ListarPeriodoPrecos();
        Task<string> AdicionarPeriodoPreco();
        Task<string> AtualizarPeriodoPreco();
    }
}
