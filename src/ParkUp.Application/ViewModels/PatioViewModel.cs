using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ParkUp.Application.ViewModels
{
    public class PatioViewModel
    {
        [Key]
        public int IdPatio { get; set; }

        public int IdEmpresa { get; set; }

        public int IdOperador { get; set; }

        public string Placa { get; set; }

        public int IdModelo { get; set; }

        public int IdCor { get; set; }

        public DateTime DataHoraEntrada { get; set; }

        public DateTime DataHoraSaida { get; set; }

        public string Permanencia { get; set; }

        public decimal Valor { get; set; }

        public int IdTipoAvulso { get; set; }

        public int IdFechamentoGeral { get; set; }
    }
}
