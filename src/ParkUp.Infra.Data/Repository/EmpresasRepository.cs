using ParkUp.Domain.Interfaces;
using ParkUp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkUp.Infra.Data.Repository
{
    public class EmpresasRepository : Repository<Empresas>, IEmpresasRepository
    {
        private readonly IEmpresasQuery _empresasQuery;
        public EmpresasRepository(IContextDapper _context, IEmpresasQuery empresasQuery)
            : base(_context, empresasQuery)
        {
            _empresasQuery = empresasQuery;
        }

        public Task<IEnumerable<Empresas>> ListarEmpresas()
        {
            return Task.FromResult(_context.ExecuteCollection<Empresas>(_empresasQuery.ListarEmpresas().Result, null));
        }
    }
}
