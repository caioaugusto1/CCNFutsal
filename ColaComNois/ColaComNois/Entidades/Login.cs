using System.ComponentModel.DataAnnotations;

namespace ColaComNois.Entidades
{
    public class Login : EntityBase
    {
        [Required]
        [Display(Name = "Nome")]
        [MaxLength(20, ErrorMessage = "Máximo permitido para o nome são 40 caracteres.")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Sobrenome")]
        [MaxLength(20, ErrorMessage = "Máximo permitido para o nome são 20 caracteres.")]
        public string SobreNome { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        [MaxLength(30, ErrorMessage = "Máximo permitido para o e-mail são 30 caracteres.")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O mínimo de {1} e o máximo de {0} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

    }
}