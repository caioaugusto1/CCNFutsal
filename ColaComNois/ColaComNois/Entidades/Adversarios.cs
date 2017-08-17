using System.ComponentModel.DataAnnotations;

namespace ColaComNois.Entidades
{
    public class Adversarios : EntityBase
    {
        [Display(Name = "Nome da Equipe")]
        [Required(ErrorMessage = "Por favor, preencha o Nome da Equipe")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(3, ErrorMessage = "Mínimo {0} caracteres")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Números e caracteres especiais não são permitidos no nome.")]
        public string Nome { get; set; }

        [Display(Name = "Nome do Responsável")]
        [Required(ErrorMessage = "Por favor, preencha o Nome do Adversário")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Números e caracteres especiais não são permitidos no nome.")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(3, ErrorMessage = "Mínimo {0} caracteres")]
        public string Responsavel { get; set; }

        [Display(Name = "N° celular de Responsável")]
        [Required(ErrorMessage = "Por favor, preencha o N° celular do Responsável")]
        public string Telefone { get; set; }

        [Display(Name = "Nota de Comportamento")]
        [Required(ErrorMessage = "Por favor, preencha a nota para o Adversário")]
        public Nota Nota { get; set; }

        [Display(Name = "Observação")]
        [Required(ErrorMessage = "Por favor, coloque uma observação para a nota")]
        public string Observacao { get; set; }
    }

    public enum Nota
    {
        [Display(Name = "Péssimo de 0 a 3")]
        P,
        [Display(Name = "Bom de 4 a 7")]
        B,
        [Display(Name = "Excelente de 8 a 10")]
        E
    }
}