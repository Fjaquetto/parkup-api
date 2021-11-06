using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkUp.Domain.Interfaces
{
    public interface IPatioQuery : IQueryBase
    {
        Task<string> GetRegistrosPatio();

        Task<string> GetRegistrosPatioById();

        Task<string> AdicionarRegistroPatio();
        Task<string> AtualizarRegistroPatio();

        Task<string> GetCaixaSaldoByPeriodo();

    }
}
