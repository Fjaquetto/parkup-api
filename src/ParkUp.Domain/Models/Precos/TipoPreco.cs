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
		public bool FlgPrecoTodosDias { get; set; }
		public bool FlgAtivo { get; set; }
		public bool FlgConvenio { get; set; }
		public bool FlgSegunda { get; set; }
		public bool FlgTerca { get; set; }
		public bool FlgQuarta { get; set; }
		public bool FlgQuinta { get; set; }
		public bool FlgSexta { get; set; }
		public bool FlgSabado { get; set; }
		public bool FlgDomingo { get; set; }
	}
}
