using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ColaComNois.Entidades
{
    public class Jogos : EntityBase
    {
        [Display(Name = "Quadro jogado")]
        [Required(ErrorMessage = "Por favor, preencha o Quadro jogado")]
        public Quadro Quadro { get; set; }


        [Display(Name = "Data do Jogo")]
        [Required(ErrorMessage = "Por favor, preencha a data do jogo")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime Data { get; set; }

        [Display(Name = "Resultado Cola Com Nois")]
        [Required(ErrorMessage = "Por favor, preencha o Resultado Cola com Nois")]
        public int ResultadoColaComNois { get; set; }

        [Display(Name = "Resultado Adversário")]
        [Required(ErrorMessage = "Por favor, preencha o Resultado Adversário")]
        public int ResultadoAdversario { get; set; }

        public bool Mandante { get; set; }

        [Display(Name = "Jogo Referente")]
        [Required(ErrorMessage = "Por favor, preencha no que refere-se esse jogo")]
        public Referente Referente { get; set; }

        [Display(Name = "Observação")]
        public string Observacao { get; set; }

        [Display(Name = "Adversário")]
        [Required(ErrorMessage = "Por favor, preencha o Adversário")]
        public int IdAdversario { get; set; }

        public virtual Adversarios Adversario { get; set; }

        //public Jogos()
        //{
        //    Adversario = new Adversarios();
        //}
    }

    public enum Quadro
    {
        [Display(Name = "1° Quadro")]
        A,
        [Display(Name = "2° Quadro")]
        B
    }

    public enum Referente
    {
        [Display(Name = "Amistoso")]
        A,
        [Display(Name = "Campeonato")]
        C,
        [Display(Name = "Festival")]
        F,
        [Display(Name = "Fut Liga")]
        L
    }
}