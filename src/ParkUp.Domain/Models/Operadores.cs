using System;
using System.Collections.Generic;
using System.Text;

namespace ParkUp.Domain.Models
{
    public class Operadores
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string CPF { get; set; }
        public bool FlgAtivo { get; set; }
    }
}
