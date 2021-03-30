﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkUp.Domain.Interfaces
{
    public interface IEmpresasQuery : IQueryBase
    {
        Task<string> ListarEmpresas();
    }
}
