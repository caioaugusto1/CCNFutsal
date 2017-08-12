using System;
using System.ComponentModel.DataAnnotations;

namespace ColaComNois.Entidades
{
    public class Despesas : EntityBase
    {
        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(3, ErrorMessage = "Mínimo {0} caracteres")]
        [Display(Name = "Nome")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Números e caracteres especiais não são permitidos no nome.")]
        public string Nome { get; set; }

        [DisplayFormat(DataFormatString = "{0,c}")]
        [Required(ErrorMessage = "Por favor, preencha o valor")]
        public decimal Valor { get; set; }

        [Display(Name = "Data de Vencimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [Required(ErrorMessage = "Por favor, preencha a Data de Vencimento")]
        public DateTime Data_Vencimento { get; set; }

        [Display(Name = "Data de Pagamento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime Data_Pagamento { get; set; }

        [Display(Name = "Status de Pagamento")]
        [Required(ErrorMessage = "Por favor, preencha o Status de Pagamento")]
        public Status StatusPagamento { get; set; }

        [Display(Name = "Observação")]
        public string Observacao { get; set; }
    }


    public enum Status
    {
        [Display(Name = "Aberto")]
        A,
        [Display(Name = "Pago")]
        P
    }
}