using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ColaComNois.Entidades
{
    public class Rateio : EntityBase
    {
        [Display(Name = "Nome do Jogador")]
        [Required(ErrorMessage = "Por favor, preencha o Jogador que efetuou o pagamento")]
        public int IdJogador { get; set; }

        [Display(Name = "Nome da Despesa")]
        [Required(ErrorMessage = "Por favor, preencha o pagamento referente a Despesa")]
        public int IdDespesa { get; set; }

        [Required(ErrorMessage = "Valor")]
        //[DisplayFormat(DataFormatString = "{0,c}")]
        public float Valor { get; set; }

        [Required(ErrorMessage = "Por favor, preencha a Data de Pagamento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [Display(Name = "Data de Pagamento")]
        public DateTime Data_Pagamento { get; set; }

        [Required(ErrorMessage = "Por favor, preencha o Recebedor")]
        [Display(Name = "Quem Recebeu?")]
        public int IdRecebedor { get; set; }

        [ScaffoldColumn(false)]
        public string NomeRecebedor { get; set; }

        [ScaffoldColumn(false)]
        public string JogadorPagou { get; set; }

        [ScaffoldColumn(false)]
        public string DespesaNome { get; set; }

        public virtual ICollection<Jogadores> Jogador { get; set; }

        public virtual Despesas Despesa { get; set; }

        //public Rateio()
        //{
        //    Jogador = new Jogadores();
        //    Despesa = new Despesas();
        //}
    }
}