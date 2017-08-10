using System.Collections.Generic;
using ColaComNois.Context;
using ColaComNois.Context.DB;
using System.Linq;

namespace ColaComNois.Repository
{
    public class JogosRepository : RepositoryBase<CCN_Jogos>
    {
        public JogosRepository(ColaComNoisContext context) : base(context)
        {
        }

        public override IList<CCN_Jogos> ObterTodos()
        {
            return _context.Jogos.OrderBy(j => j.Data).ToList();
        }
    }
}