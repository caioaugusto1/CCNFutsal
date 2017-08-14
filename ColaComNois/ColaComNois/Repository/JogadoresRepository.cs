using ColaComNois.Context;
using ColaComNois.Context.DB;
using ColaComNois.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ColaComNois.Repository
{
    public class JogadoresRepository : RepositoryBase<ccn_jogadores>, IJogadoresRepository
    {
        public JogadoresRepository(ColaComNoisContext context)
            : base(context)
        {

        }

        public IList<ccn_jogadores> ObterAtivos()
        {
            return ObterTodos().Where(j => j.Data_Admissao != null).ToList();
        }

        public IList<ccn_jogadores> ObterComissao()
        {
            return ObterTodos().Where(c => c.Comissao).ToList();
        }

        public override IList<ccn_jogadores> ObterTodos()
        {
            return _context.Jogadores.OrderBy(j => j.Nome)
                .ThenBy(j => j.Data_Nascimento)
                .ThenBy(j => j.Data_Admissao)
                .ToList();
        }
    }
}