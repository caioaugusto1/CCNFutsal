using ColaComNois.Context;
using ColaComNois.Context.DB;
using ColaComNois.Entidades;
using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace ColaComNois.Repository
{
    public class RateiosRepository : RepositoryBase<ccn_rateios>
    {
        string connectionString = ConnectionString.Connection();

        public RateiosRepository(ColaComNoisContext context)
            : base(context)
        {

        }

        public override IList<ccn_rateios> ObterTodos()
        {
            return _context.Rateios.OrderBy(r => r.Data_Pagamento)
                .ThenBy(r => r.ccn_jogadores.Nome)
                .ToList();
        }

        public IList<Rateio> ObteImprovisado()
        {
            var sql = "select r.Id, r.Valor, r.IdDespesa, r.Data_Pagamento, " +
                "d.Nome as DespesaNome, j.Nome as JogadorPagou, j.Nome as NomeRecebedor " +
                "from ccn_rateios r inner join ccn_jogadores j on r.IdJogador = j.Id " +
                "inner join ccn_despesas d on d.Id = r.IdDespesa " +
                "Order by JogadorPagou and r.Data_Pagamento desc ";

            return _context.Database.Connection
                .Query<Rateio>(sql).ToList();
        }

        //public override IList<CCN_Rateios> ObterTodos()
        //{
        //    using (SqlConnection connSql = new SqlConnection(connectionString))
        //    {
        //        SqlCommand cmdSql = new SqlCommand("select CCN_Rateios.Id, CCN_Rateios.Valor, CCN_Rateios.Data_Pagamento, " +
        //        "ccn_jogadores.Id, ccn_jogadores.Nome as JogadorNome, CCN_Despesas.Nome as DespesaNome " +
        //        "from CCN_Rateios inner join ccn_jogadores on ccn_jogadores.Id = IdJogador " +
        //        "inner join CCN_Despesas on CCN_Despesas.Id = IdDespesa order by JogadorNome " +
        //        "select ccn_jogadores.Nome as RecebedorNome from ccn_jogadores inner join CCN_Rateios " +
        //        " on ccn_jogadores.Id = CCN_Rateios.IdRecebedor", connSql);

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

        //public override IList<CCN_Rateios> ObterTodos()
        //{
        //    var sql = "select CCN_Rateios.Id, CCN_Rateios.Valor, CCN_Rateios.Data_Pagamento" +
        //        "ccn_jogadores.Id, ccn_jogadores.Nome as JogadorNome, CCN_Despesas.Nome as DespesaNome from CCN_Rateios " +
        //        "inner join ccn_jogadores on ccn_jogadores.Id = IdJogador " +
        //        "inner join CCN_Despesas on CCN_Despesas.Id = IdDespesa order by JogadorNome" +
        //        "select ccn_jogadores.Nome as RecebedorNome from ccn_jogadores inner join CCN_Rateios" +
        //        "on ccn_jogadores.Id = CCN_Rateios.IdRecebedor";

        //    return _context.Database.Connection.Query<CCN_Rateios>(sql)
        //        .OrderBy(c => c.Data_Pagamento)
        //        .ToList();
        //}
    }
}
