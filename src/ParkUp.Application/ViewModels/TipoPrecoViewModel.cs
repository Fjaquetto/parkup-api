using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ParkUp.Application.ViewModels
{
    public class TipoPrecoViewModel
    {
        [Key]
        public int Id { get; set; }
		
		public DateTime DataCadastro { get; set; }
		
		public DateTime? DataUltimaAlteracao { get; set; }
		
		[Required(ErrorMessage = "Informar o IdEmpresa")]
		public int IdEmpresa { get; set; }
		
		[Required(ErrorMessage = "Informar a Descrição")]
		public string Descricao { get; set; }
		
		public int TempoToleranciaEntrada { get; set; }
		
		public bool FlgPrecoUnico { get; set; }
	
		public bool FlgAtivo { get; set; }		
		public bool FlgConvenio { get; set; }
		[Range(12, 24, ErrorMessage = "Informe entre 12 e 24 horas")]
		public int HoraMaximoDiaria { get; set; }
		public int TempoToleranciaSaida { get; set; }
		public decimal ValorHoraAdicional { get; set; }
	}
}
