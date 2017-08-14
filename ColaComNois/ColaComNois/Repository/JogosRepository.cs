using System.Collections.Generic;
using ColaComNois.Context;
using ColaComNois.Context.DB;
using System.Linq;

namespace ColaComNois.Repository
{
    public class JogosRepository : RepositoryBase<ccn_jogos>
    {
        public JogosRepository(ColaComNoisContext context) : base(context)
        {
        }

        public override IList<ccn_jogos> ObterTodos()
        {
            return _context.Jogos.OrderBy(j => j.Data).ToList();
        }
    }
}