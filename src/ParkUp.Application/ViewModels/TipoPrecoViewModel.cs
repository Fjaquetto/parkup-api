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
		
		[Required(ErrorMessage = "É necessário que o campo esteja preenchido.")]
		public int IdEmpresa { get; set; }
		
		[Required(ErrorMessage = "É necessário que o campo esteja preenchido.")]
		public string Descricao { get; set; }
		
		public int TempoToleranciaEntrada { get; set; }
		
		public bool FlgPrecoUnico { get; set; }
	
		public bool FlgAtivo { get; set; }
		
		public bool FlgConvenio { get; set; }

		public int HoraMaximoDiaria { get; set; }
	}
}
