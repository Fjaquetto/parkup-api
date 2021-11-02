using ParkUp.Domain.Interfaces;
using ParkUp.Domain.Models;
using ParkUp.Domain.Models.Precos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkUp.Infra.Data.Repository
{
    public class PeriodoPrecoRepository: Repository<PeriodoPreco>, IPeriodoPrecoRepository    
    {
        private readonly IPeriodoPrecoQuery _querie;
        public PeriodoPrecoRepository(IContextDapper _context, IPeriodoPrecoQuery query)
            : base(_context, query)
        {
            _querie = query;
        }

        public Task<PeriodoPreco> AdicionarPeriodoPreco(PeriodoPreco periodoPreco)
        {
            return Task.FromResult(_context.ExecuteScalar<PeriodoPreco>(_querie.AdicionarPeriodoPreco().Result, periodoPreco));
        }

        public Task<int> AtualizarPeriodoPreco(PeriodoPreco periodoPreco)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PeriodoPreco>> ListarPeriodoPrecos(int IdTipoPreco)
        {
            throw new NotImplementedException();
        }
    }
}
