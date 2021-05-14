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
        Task<Empresas> AdicionarEmpresa(Empresas empresa);
        Task<int> AtualizarEmpresa(Empresas empresa);
        Task<Empresas> ObterEmpresaPorId(int id);
        Task<int> DesativarEmpresa(int id);
    }
}
