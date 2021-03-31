using ParkUp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkUp.Infra.Data.Repository.Queries
{
    public class EmpresasQuery : QueryBase, IEmpresasQuery
    {
        public Task<string> ListarEmpresas()
        {
            return Task.FromResult(@"
                        SELECT * FROM Empresas WITH (NOLOCK)
                    ");
        }

        public Task<string> AdicionarEmpresa()
        {
            return Task.FromResult(@"
                        INSERT INTO Empresas
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

        public Task<string> AtualizarEmpresa()
        {
            return Task.FromResult(@"
                        UPDATE Empresas
                        SET NomeEmpresa = @NomeEmpresa,
                            CNPJ = @CNPJ,
                            IE = @IE,
                            Endereco = @Endereco,
                            CEP = @CEP,
                            Cidade = @Cidade,
                            Estado = @Estado,
                            Email = @Email,
                            Telefone = @Telefone
                        WHERE Id = @Id
                ");
        }
    }
}
