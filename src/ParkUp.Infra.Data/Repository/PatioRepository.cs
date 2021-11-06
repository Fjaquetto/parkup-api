using ParkUp.Domain.Interfaces;
using ParkUp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkUp.Infra.Data.Repository
{
    public class PatioRepository : Repository<Patio>, IPatioRepository
    {
        private readonly IPatioQuery _patioQuery;

        public PatioRepository(IContextDapper _context, IPatioQuery patioQuery) : base(_context, patioQuery)
        {
            _patioQuery = patioQuery;
        }

        public Task<IEnumerable<PatioCaixa>> GetCaixaSaldoByPeriodo(int idEmpresa, DateTime periodo)
        {
            return Task
                .FromResult(_context.ExecuteCollection<PatioCaixa>(_patioQuery.GetCaixaSaldoByPeriodo().Result, 
                new { IdEmpresa=idEmpresa, Ano=periodo.Year,Mes=periodo.Month,Dia=periodo.Day }));
        }

        public Task<IEnumerable<Patio>> GetRegistrosPatio()
        {
            return Task.FromResult(_context.ExecuteCollection<Patio>(_patioQuery.GetRegistrosPatio().Result, null));
        }

        public Task<int> GetRegistrosPatioById(int idPatio)
        {
            return Task.FromResult(_context.ExecuteScalar<int>(_patioQuery.GetRegistrosPatioById().Result, idPatio));
        }

        public Task<Patio> PostRegistroPatio(Patio registroPatio)
        {
            return Task.FromResult(_context.ExecuteScalar<Patio>(_patioQuery.AdicionarRegistroPatio().Result, registroPatio));
        }

        public Task<int> PutRegistroPatio(Patio registroPatio)
        {
            return Task.FromResult(_context.ExecuteScalar<int>(_patioQuery.AtualizarRegistroPatio().Result, registroPatio));
        }
    }
}
