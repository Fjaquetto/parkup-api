using System;
using System.Collections.Generic;
using System.Text;

namespace ParkUp.Domain.Models.Precos
{
	public class PeriodoPreco
	{
		public int Id { get; set; }
		public int IdTipoPreco { get; set; }
		public int Periodo { get; set; }
		public decimal Valor { get; set; }	

	}
}
