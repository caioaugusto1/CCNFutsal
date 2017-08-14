using ColaComNois.Context.DB;
using System.Collections.Generic;

namespace ColaComNois.Repository.Interfaces
{
    public interface IJogadoresRepository
    {
        IList<ccn_jogadores> ObterComissao();

        IList<ccn_jogadores> ObterAtivos();
    }
}
