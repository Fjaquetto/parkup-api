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

        public Task<IEnumerable<Patio>> ListarRegistroPatio()
        {
            return Task.FromResult(_context.ExecuteCollection<Patio>(_patioQuery.ListarRegistroPatio().Result, null));
        }
    }
}
