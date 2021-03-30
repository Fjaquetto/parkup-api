using ParkUp.Domain.Interfaces;
using ParkUp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
