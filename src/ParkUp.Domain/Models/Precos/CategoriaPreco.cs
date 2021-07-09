using System;
using System.Collections.Generic;
using System.Text;

namespace ParkUp.Domain.Models.Precos
{
	public class CategoriaPreco
	{
		public int Id { get; set; }
		public int IdTipoPreco { get; set; }
		public int IdCategoria { get; set; }
	}
}
