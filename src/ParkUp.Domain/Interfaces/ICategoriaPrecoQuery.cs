using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkUp.Domain.Interfaces
{
    public interface ICategoriaPrecoQuery : IQueryBase
    {
        Task<string> ListarCategoriaPrecos();
        Task<string> AdicionarCategoriaPreco();
        Task<string> AtualizarCategoriaPreco();
    }
}
