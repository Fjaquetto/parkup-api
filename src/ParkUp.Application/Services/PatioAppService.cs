using AutoMapper;
using ParkUp.Application.Interfaces;
using ParkUp.Application.ViewModels;
using ParkUp.Domain.Interfaces;
using ParkUp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkUp.Application.Services
{
    public class PatioAppService: IPatioAppService
    {
        private readonly IPatioRepository _patioRepository;
        private readonly ITipoPrecoAppService _tipoPrecoAppService;
        private readonly IPeriodoPrecoAppService _periodoPrecoAppService;
        private readonly IMapper _automapper;

        public PatioAppService(IPatioRepository patioRepository, 
            IMapper automapper,
            ITipoPrecoAppService tipoPrecoAppService,
            IPeriodoPrecoAppService periodoPrecoAppService)
        {
            _patioRepository = patioRepository;
            _automapper = automapper;
            _tipoPrecoAppService = tipoPrecoAppService;
            _periodoPrecoAppService = periodoPrecoAppService;
        }

        public async Task<IEnumerable<PatioViewModel>> GetRegistrosPatio()
        {
            return _automapper.Map<IEnumerable<PatioViewModel>>(await _patioRepository.GetRegistrosPatio());
        }

        public async Task<int> GetRegistrosPatioById(int idPatio)
        {
            return await _patioRepository.GetRegistrosPatioById(idPatio);
        }

        public async Task<PatioViewModel> PostRegistroPatio(PatioViewModel registroPatio)
        {
            return _automapper.Map<PatioViewModel>(await _patioRepository.PostRegistroPatio(_automapper.Map<Patio>(registroPatio)));
        }

        public async Task<int> PutRegistroPatio(PatioViewModel registroPatio)
        {
            return await _patioRepository.PutRegistroPatio(_automapper.Map<Patio>(registroPatio));
        }

        public async Task<PatioViewModel> PatchSaidaVeiculo(PatioViewModel registroPatio)
        {
            registroPatio.Valor = await CalcularValor(registroPatio);
            registroPatio.Permanencia = await CalcularPermanencia(registroPatio);

            return registroPatio;
        }

        #region PRIVATE AREA
        private async Task<decimal> CalcularValor(PatioViewModel patio)
        {
            //Total de Minutos Estacionado (Data Saida - Data Entrada)
            var totalMinutos = (patio.DataHoraSaida - patio.DataHoraEntrada).TotalMinutes;

            var tipoPreco = await _tipoPrecoAppService.GetTipoPreco(patio.IdTipoAvulso);
            var periodoPrecos = await _periodoPrecoAppService.ListarTodosPrecosByIdTipoPreco(patio.IdTipoAvulso);
            var periodoMaximo = periodoPrecos.First(p => p.Periodo == periodoPrecos.Max(m => m.Periodo));

            var toleranciaEntrada = tipoPreco.TempoToleranciaEntrada;
            var toleranciaTrocaPeriodo = 5;

            if (totalMinutos == 0) totalMinutos = 1;

            //Caso exista uma tolerância de Entrada e o tempo estacionado seja menor ou igual a essa tolerancia, o valor cobrado deverá ser 0 (zero)
            if (totalMinutos <= toleranciaEntrada) return 0;

            //Caso tenha tolerancia entre troca dos Períodos, desconta do total de minutos em que o veiculo ficou estacionado
            totalMinutos -= toleranciaTrocaPeriodo > 0 && totalMinutos > toleranciaTrocaPeriodo ? toleranciaTrocaPeriodo : 0;

            //Caso o tempo seja menor ou igual ao Periodo Minimo, ja retorna o valor sem precisar fazer nenhum calculo adicional
            if (totalMinutos <= periodoPrecos.First(p => p.Periodo == periodoPrecos.Min(m => m.Periodo)).Periodo)
                return periodoPrecos.Where(p => totalMinutos <= p.Periodo).First().Valor;

            //Não ultrapassou o período Máximo, neste caso tambem retorna o valor sem a necessidade de fazer nenhum calculo adicional
            if (totalMinutos <= periodoMaximo.Periodo)
                return periodoPrecos.Where(p => p.Periodo >= totalMinutos).OrderBy(o => o.Periodo).First().Valor;

            //Aqui tem que fazer o calculo, pois ultrapassou o limite Maximo do Periodo           
            var valorPeriodoMaximo = periodoMaximo.Valor;
            var valorAdicional = periodoMaximo.ValorHoraAdicional;
            var tempoHoraAdicional = Convert.ToInt32(Math.Floor((totalMinutos - periodoMaximo.Periodo) / 60));

            if (((totalMinutos - periodoMaximo.Periodo) % 60) > 0)
                tempoHoraAdicional += 1;

            var valorCalculado = valorPeriodoMaximo + (Convert.ToDecimal(tempoHoraAdicional) * Convert.ToDecimal(valorAdicional));

            return valorCalculado;
        }
        
        private async Task<string> CalcularPermanencia(PatioViewModel patio)
        {
            var tempoPermanencia = (patio.DataHoraSaida - patio.DataHoraEntrada);

            var horas = $"{tempoPermanencia.Hours}h";
            var minutos = $"{tempoPermanencia.Minutes}min";

            return await Task.FromResult($"{horas}{minutos}");
        }

        #endregion

    }
}
