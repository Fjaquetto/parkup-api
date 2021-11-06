﻿using ParkUp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkUp.Infra.Data.Repository.Queries
{
    public class PatioQuery : IPatioQuery
    {
        public Task<string> GetRegistrosPatio()
        {
            return Task.FromResult(
                @"SELECT * FROM Patio WITH (NOLOCK)"
                );
        }

        public Task<string> GetRegistrosPatioById()
        {
            return Task.FromResult(
                @"SELECT * FROM Patio WITH (NOLOCK)
                    WHERE IdPatio = @idPatio"
                );
        }

        public Task<string> AdicionarRegistroPatio()
        {
            return Task.FromResult(@"
                INSERT INTO Patio VALUES (
                @IdEmpresa,
                @IdOperador,
                @Placa,
                @IdModelo,                
                @DataHoraEntrada,
                @DataHoraSaida,
                @Permanencia,
                @Valor,
                @IdTipoAvulso,
                @IdFechamentoGeral,
                @IdOperadorSaida
                )");
        }

        public Task<string> AtualizarRegistroPatio()
        {
            return Task.FromResult(@"
                UPDATE Patio
                SET IdEmpresa = @IdEmpresa,
                    IdOperador = @IdOperador,
                    Placa = @Placa,
                    IdModelo = @IdModelo,                 
                    DataHoraEntrada = @DataHoraEntrada,
                    DataHoraSaida = @DataHoraSaida,
                    Permanencia = @Permanencia,
                    Valor = @Valor,
                    IdTipoAvulso = @IdTipoAvulso,
                    IdFechamentoGeral = @IdFechamentoGeral,
                    IdOperadorSaida = @IdOperadorSaida
                WHERE IdPatio = @IdPatio
                ");
        }

        public string Add()
        {
            throw new NotImplementedException();
        }

        public string GetAll()
        {
            throw new NotImplementedException();
        }

        public string GetByFilter()
        {
            throw new NotImplementedException();
        }

        public string GetById()
        {
            throw new NotImplementedException();
        }

        public string Remove()
        {
            throw new NotImplementedException();
        }

        public string Update()
        {
            throw new NotImplementedException();
        }
    }
}
