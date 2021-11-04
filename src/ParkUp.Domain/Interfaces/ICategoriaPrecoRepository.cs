using ParkUp.Domain.Models;
using ParkUp.Domain.Models.Precos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkUp.Domain.Interfaces
{
    public interface ICategoriaPrecoRepository : IRepository<CategoriaPreco>
    {
        Task<IEnumerable<CategoriaPreco>> ListarCategoriasPrecos(int IdTipoPreco);
        Task<Empresas> AdicionarCategoriaPreco(CategoriaPreco categoriaPreco);
        Task<int> AtualizarCategoriaPreco(CategoriaPreco categoriaPreco);
    }
}
