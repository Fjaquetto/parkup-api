using ParkUp.Domain.Interfaces;
using ParkUp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkUp.Infra.Data.Repository
{
    public class TipoPrecoRepository : Repository<TipoPreco>, ITipoPrecoRepository
    {
        private readonly ITipoPrecoQuery _tipoPrecoQuery;
        public TipoPrecoRepository(IContextDapper _context, ITipoPrecoQuery tipPrecoQuery)
            : base(_context, tipPrecoQuery)
        {
            _tipoPrecoQuery = tipPrecoQuery;
        }

        public Task<TipoPreco> AdicionarTipoPreco(TipoPreco tipoPreco)
        {
            return Task.FromResult(_context.ExecuteScalar<TipoPreco>(_tipoPrecoQuery.AdicionarTipoPreco().Result, tipoPreco));
        }

        public Task<int> AtualizarTipoPreco(TipoPreco tipoPreco)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TipoPreco>> ListarPrecos(int IdEmpresa)
        {
            throw new NotImplementedException();
        }
    }
}
