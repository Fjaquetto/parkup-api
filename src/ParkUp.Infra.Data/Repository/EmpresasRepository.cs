using ParkUp.Domain.Interfaces;
using ParkUp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ParkUp.Domain.Enums.TipoEmpresaEnum;

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
            return Task.FromResult(_context.ExecuteObject<Empresas>(_empresasQuery.AdicionarEmpresa().Result, empresa));
        }

        public Task<Empresas> AtualizarEmpresa(Empresas empresa)
        {
            return Task.FromResult(_context.ExecuteObject<Empresas>(_empresasQuery.AtualizarEmpresa().Result, empresa));
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

        public Task<IEnumerable<TipoEmpresa>> RetornarEnumTipoEmpresa()
        {
            return Task.FromResult(Enum.GetValues(typeof(TipoEmpresa)).Cast<TipoEmpresa>());
        }

        public Task<Empresas> VerificaExistenciaEmpresa(Empresas empresa)
        {
            return Task.FromResult(_context.ExecuteObject<Empresas>(_empresasQuery.VerificaExistenciaEmpresa().Result, empresa));
        }
    }
}
