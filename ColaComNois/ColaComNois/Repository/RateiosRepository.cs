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
    }
}
