using ParkUp.Domain.Models;
using ParkUp.Domain.Models.Precos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkUp.Domain.Interfaces
{
    public interface IPeriodoPrecoRepository : IRepository<PeriodoPreco>
    {
        Task<IEnumerable<PeriodoPreco>> ListarPeriodoPrecos(int IdTipoPreco);
        Task<PeriodoPreco> AdicionarPeriodoPreco(PeriodoPreco periodoPreco);
        Task<int> AtualizarPeriodoPreco(PeriodoPreco periodoPreco);
        Task<IEnumerable<PeriodoPreco>> ListarPeriodoPrecosByIdTipoPreco(int IdTipoPreco);
    }
}
