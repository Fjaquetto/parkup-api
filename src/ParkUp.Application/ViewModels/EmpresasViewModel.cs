using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ParkUp.Application.ViewModels
{
    public class EmpresasViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string TipoEmpresa { get; set; }

        [Required(ErrorMessage = "É necessário que o campo esteja preenchido.")]
        [MinLength(3, ErrorMessage = "É necessário que o campo contenha no mínimo 3 caracteres.")]
        [MaxLength(80, ErrorMessage = "É necessário que o campo contenha no máximo 80 caracteres.")]
        public string NomeEmpresa { get; set; }

        [Required(ErrorMessage = "É necessário que o campo esteja preenchido.")]
        [MinLength(14, ErrorMessage = "É necessário que o campo contenha 14 caracteres")]
        [MaxLength(14, ErrorMessage = "É necessário que o campo contenha 14 caracteres")]
        public string CNPJ { get; set; }

        [MinLength(14, ErrorMessage = "É necessário que o campo contenha 14 caracteres")]
        [MaxLength(14, ErrorMessage = "É necessário que o campo contenha 14 caracteres")]
        public string IE { get; set; }

        [Required(ErrorMessage = "É necessário que o campo esteja preenchido.")]
        [MinLength(14, ErrorMessage = "É necessário que o campo contenha no mínimo 14 caracteres")]
        [MaxLength(50, ErrorMessage = "É necessário que o campo contenha no máximo 50 caracteres")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "É necessário que o campo esteja preenchido.")]
        [MinLength(9, ErrorMessage = "É necessário que o campo contenha 9 caracteres")]
        [MaxLength(9, ErrorMessage = "É necessário que o campo contenha 9 caracteres")]
        public string CEP { get; set; }
            
        [Required(ErrorMessage = "É necessário que o campo esteja preenchido.")]
        [MinLength(3, ErrorMessage = "É necessário que o campo contenha no mínimo 3 caracteres")]
        [MaxLength(30, ErrorMessage = "É necessário que o campo contenha no máximo 30 caracteres")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "É necessário que o campo esteja preenchido.")]
        [MinLength(3, ErrorMessage = "É necessário que o campo contenha no mínimo 3 caracteres")]
        [MaxLength(30, ErrorMessage = "É necessário que o campo contenha no máximo 30 caracteres")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "É necessário que o campo esteja preenchido.")]
        [MinLength(8, ErrorMessage = "É necessário que o campo contenha no mínimo 8 caracteres")]
        [MaxLength(70, ErrorMessage = "É necessário que o campo contenha no máximo 70 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "É necessário que o campo esteja preenchido.")]
        [MinLength(14, ErrorMessage = "É necessário que o campo contenha 14 caracteres")]
        [MaxLength(14, ErrorMessage = "É necessário que o campo contenha 14 caracteres")]
        public string Telefone { get; set; }

        public DateTime DataCadastro { get; set; }

        public bool FlgAtivo { get; set; }
    }
}
