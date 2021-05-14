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

        public Task<Empresas> AdicionarEmpresa(Empresas empresa)
        {
            return Task.FromResult(_context.ExecuteScalar<Empresas>(_empresasQuery.AdicionarEmpresa().Result, empresa));
        }

        public Task<int> AtualizarEmpresa(Empresas empresa)
        {
            return Task.FromResult(_context.ExecuteScalar<int>(_empresasQuery.AtualizarEmpresa().Result, empresa));
        }

        public Task<Empresas> ObterEmpresaPorId(int id)
        {
            return Task.FromResult(
                _context.ExecuteObject<Empresas>(_empresasQuery.ObterEmpresaPorId().Result, new { Id = id }));
        }

        public Task<int> DesativarEmpresa(int id)
        {
            return Task.FromResult(_context.Execute(_empresasQuery.DesativarEmpresa().Result, new { Id = id }));
        }
    }
}
