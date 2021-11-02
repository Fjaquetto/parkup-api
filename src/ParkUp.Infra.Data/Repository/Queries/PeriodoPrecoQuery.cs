using ParkUp.Domain.Interfaces;
using ParkUp.Infra.Data.Repository.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkUp.Infra.Data.Repository.Queries
{
    public class PeriodoPrecoQuery : QueryBase, IPeriodoPrecoQuery
    {
        public Task<string> AdicionarPeriodoPreco()
        {
            return Task.FromResult(@"INSERT INTO PeriodoPreco(IdTipoPreco,Periodo,Valor,TempoToleranciaSaida,ValorHoraAdicional)
            VALUES(@IdTipoPreco,@Periodo,@Valor,@TempoToleranciaSaida,@ValorHoraAdicional)            
            ");
        }

        public Task<string> AtualizarPeriodoPreco()
        {
            throw new NotImplementedException();
        }

        public Task<string> ListarPeriodoPrecos()
        {
            throw new NotImplementedException();
        }

        public Task<string> ListarPeriodoPrecosByIdTipoPreco()
        {
            return Task.FromResult(@"SELECT * FROM PeriodoPreco WHERE IdTipoPreco = @idTipoPreco          
            ");
        }
    }
}
