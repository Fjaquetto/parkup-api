using ParkUp.Application.Interfaces;
using ParkUp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkUp.Application.Services
{
    public class EmpresasAppService : IEmpresasAppService
    {
        private readonly IEmpresasRepository _empresasRepository;
        public EmpresasAppService(IEmpresasRepository empresasRepository)
        {
            _empresasRepository = empresasRepository;
        }
    }
}
