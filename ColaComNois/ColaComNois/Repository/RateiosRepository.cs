using ColaComNois.Context;
using ColaComNois.Context.DB;
using System.Collections.Generic;
using System.Linq;

namespace ColaComNois.Repository
{
    public class RateiosRepository : RepositoryBase<CCN_Rateios>
    {
        string connectionString = ConnectionString.Connection();

        public RateiosRepository(ColaComNoisContext context)
            : base(context)
        {

        }

        //public override IList<CCN_Rateios> ObterTodos()
        //{
        //    using (SqlConnection connSql = new SqlConnection(connectionString))
        //    {
        //        SqlCommand cmdSql = new SqlCommand("select CCN_Rateios.Id, CCN_Rateios.Valor, CCN_Rateios.Data_Pagamento, " +
        //        "CCN_Jogadores.Id, CCN_Jogadores.Nome as JogadorNome, CCN_Despesas.Nome as DespesaNome " +
        //        "from CCN_Rateios inner join CCN_Jogadores on CCN_Jogadores.Id = IdJogador " +
        //        "inner join CCN_Despesas on CCN_Despesas.Id = IdDespesa order by JogadorNome " +
        //        "select CCN_Jogadores.Nome as RecebedorNome from CCN_Jogadores inner join CCN_Rateios " +
        //        " on CCN_Jogadores.Id = CCN_Rateios.IdRecebedor", connSql);

        //        connSql.Open();

        //        var rateios = new List<Rateio>();

        //        using (SqlDataReader sdr = cmdSql.ExecuteReader())
        //        {
        //            var rateio = new Rateio();

        //            if (sdr.Read())
        //            {
        //                rateio.Id = (int)sdr["Id"];
        //                rateio.Valor = (decimal)sdr["Valor"];
        //                rateio.Jogador.Nome = (string)sdr["JogadorNome"];
        //                rateio.NomeRecebedor = "Eae";
        //                //rateio.NomeRecebedor = ((string)sdr["RecebedorNome"]);
        //                rateio.Despesa.Nome = ((string)sdr["DespesaNome"]);
        //                rateio.Data_Pagamento = (DateTime)sdr["Data_Pagamento"];
        //            }

        //            rateios.Add(rateio);
        //        }

        //        connSql.Close();

        //        var e = Mapper.Map<IList<Rateio>, IList<CCN_Rateios>>(rateios);

        //        return e;
        //    }

        public override IList<CCN_Rateios> ObterTodos()
        {
            var resultados = _context.Rateios
                .OrderBy(r => r.Data_Pagamento)
                .ThenBy(r => r.CCN_Despesas.Nome);

            return resultados.ToList();
        }
    }
}