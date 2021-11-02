﻿using ParkUp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkUp.Domain.Interfaces
{
    public interface IPatioRepository : IRepository<Patio>
    {
        Task<IEnumerable<Patio>> GetRegistrosPatio();

        Task<int> GetRegistrosPatioById(int idPatio);

        Task<Patio> PostRegistroPatio(Patio registroPatio);

        Task<int> PutRegistroPatio(Patio registroPatio);
    }
}
