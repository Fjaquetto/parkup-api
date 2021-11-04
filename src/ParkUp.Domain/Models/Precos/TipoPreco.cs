using System;
using System.Collections.Generic;
using System.Text;

namespace ParkUp.Domain.Models
{
	public class TipoPreco
	{
		public int Id { get; set; }		
		public DateTime? DataUltimaAlteracao { get; set; }
		public int IdEmpresa { get; set; }
		public string Descricao { get; set; }
		public int TempoToleranciaEntrada { get; set; }
		public bool FlgPrecoUnico { get; set; }		
		public bool FlgAtivo { get; set; }
		public bool FlgConvenio { get; set; }		
		public int HoraMaximoDiaria { get; set; }
		public DateTime DataCadastro { get; set; }
		public int TempoToleranciaSaida { get; set; }
		public decimal ValorHoraAdicional { get; set; }

	}
}
