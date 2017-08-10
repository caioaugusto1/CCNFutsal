using System;
using System.ComponentModel.DataAnnotations;

namespace ColaComNois.Entidades
{
    public class Jogadores : EntityBase
    {
        [Required(ErrorMessage = "Por favor, preencha o campo Nome")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(3, ErrorMessage = "Mínimo {0} caracteres")]
        [Display(Name = "Nome Completo")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Números e caracteres especiais não são permitidos no nome.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, preencha o RG")]
        [Display(Name = "Número de RG")]
        [MaxLength(12, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(12, ErrorMessage = "Mínimo {0} caracteres")]
        public string RG { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Por favor, preencha a Data de Nascimento")]
        [Required(ErrorMessage = "Por favor, preencha a data de Nascimento")]
        public DateTime Data_Nascimento { get; set; }
                
        [Display(Name = "Data de Admissão")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [Required(ErrorMessage = "Por favor, preencha a Data de Admissão")]
        public DateTime Data_Admissao { get; set; }

        [ScaffoldColumn(false)]
        public DateTime Data_Demissao { get; set; }

        [Display(Name = "É Comissão?")]
        public bool Comissao { get; set; }
        
    }
}