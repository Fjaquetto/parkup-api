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
		
		public DateTime? DataUltimaAlteracao { get; set; }
		
		[Required(ErrorMessage = "É necessário que o campo esteja preenchido.")]
		public int IdEmpresa { get; set; }
		
		[Required(ErrorMessage = "É necessário que o campo esteja preenchido.")]
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
