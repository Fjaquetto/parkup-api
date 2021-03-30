using ParkUp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkUp.Infra.Data.Repository.Queries
{
    public class EmpresasQuery : IEmpresasQuery
    {
        public Task<string> ListarEmpresas()
        {
            return Task.FromResult(@"
                        SELECT * FROM Empresas WITH (NOLOCK)
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
