using ParkUp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkUp.Infra.Data.Repository.Queries
{
    public class PatioQuery : IPatioQuery
    {
        public Task<string> ListarRegistroPatio()
        {
            return Task.FromResult(
                @"SELECT * FROM Patio WITH (NOLOCK)"
                );
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
