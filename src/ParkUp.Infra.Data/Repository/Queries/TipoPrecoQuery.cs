using ParkUp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkUp.Infra.Data.Repository.Queries
{
    public class TipoPrecoQuery : QueryBase, ITipoPrecoQuery
    {
        public Task<string> AdicionarTipoPreco()
        {
            return Task.FromResult(@"
                        INSERT INTO TipoPreco(
                         DataCadastro,
                         IdEmpresa,
                         Descricao,
                         TempoToleranciaEntrada,
                         FlgPrecoUnico,
                            

                        )
                        VALUES (
                            @NomeEmpresa,
                            @CNPJ,
                            @IE,
                            @Endereco,
                            @CEP,
                            @Cidade,
                            @Estado,
                            @Email,
                            @Telefone
                            )
                    ");
        }

        public Task<string> AtualizarTipoPreco()
        {
            throw new NotImplementedException();
        }

        public Task<string> ListarPrecos()
        {
            throw new NotImplementedException();
        }
    }
}
