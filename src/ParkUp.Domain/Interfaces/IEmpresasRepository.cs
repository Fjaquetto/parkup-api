using ParkUp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkUp.Domain.Interfaces
{
    public interface IEmpresasRepository : IRepository<Empresas>
    {
        Task<IEnumerable<Empresas>> ListarEmpresas();
    }
}
