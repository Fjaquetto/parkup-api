using ParkUp.Domain.Models;
using System;
using System.Collections;
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
        Task<IEnumerable<PatioCaixa>> GetCaixaSaldoByPeriodo(int idEmpresa,DateTime periodo);

        Task<Patio> GetVeiculoPatioByPlaca(int idEmpresa,string placa);
    }
}
