using ColaComNois.Context.DB;
using ColaComNois.Entidades;
using System;

namespace ColaComNois.Repository.Adpters
{
    public static class RateioAdapter
    {
        public static Rateio ToDomain(this ccn_rateios dbRateios)
        {
            if (dbRateios == null)
                return null;

            return new Rateio
            {
                Id = dbRateios.Id,
                IdDespesa = dbRateios.IdDespesa,
                IdJogador = dbRateios.IdRecebedor,
                IdRecebedor = dbRateios.IdRecebedor,
                Valor = float.Parse(dbRateios.Valor.ToString()),
                Data_Pagamento = dbRateios.Data_Pagamento
            };
        }

        public static ccn_rateios ToDbEntity(this Rateio domain)
        {
            if (domain == null)
                return null;

            return new ccn_rateios
            {
                Id = domain.Id,
                IdDespesa = domain.IdDespesa,
                IdJogador = domain.IdRecebedor,
                IdRecebedor = domain.IdRecebedor,
                Valor = Convert.ToDecimal(domain.Valor),
                Data_Pagamento = domain.Data_Pagamento
            };
        }
    }
}