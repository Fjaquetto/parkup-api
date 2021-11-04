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
                         FlgAtivo,
                         FlgConvenio,
                         HoraMaximoDiaria,
                         TempoToleranciaSaida,
                         ValorHoraAdicional

                        )
                        VALUES (
                            @DataCadastro,
                            @IdEmpresa,
                            @Descricao,
                            @TempoToleranciaEntrada,
                            @FlgPrecoUnico,
                            @FlgAtivo,
                            @FlgConvenio,
                            @HoraMaximoDiaria,
                            @TempoToleranciaSaida,
                            @ValorHoraAdicional
                            )
                        SELECT @@IDENTITY;
                    ");
        }

        public Task<string> AtualizarTipoPreco()
        {
            return Task.FromResult(@"
                        UPDATE TipoPreco SET DataUltimaAlteracao=@DataUltimaAlteracao, 
                        Descricao = @Descricao,
                        FlgAtivo = @FlgAtivo,
                        TempoToleranciaEntrada=@TempoToleranciaEntrada,
                        TempoToleranciaSaida = @TempoToleranciaSaida
                        WHERE Id=@Id
                    ");
        }

        public Task<string> ListarPrecos()
        {
            return Task.FromResult(@"
                        SELECT * FROM TipoPreco where IdEmpresa=@IdEmpresa
                    ");
        }

        public Task<string> RecuperarTipoPreco()
        {
            return Task.FromResult(@"
                        SELECT * FROM TipoPreco where Id=@idTipoPreco
                    ");
        }
    }
}
