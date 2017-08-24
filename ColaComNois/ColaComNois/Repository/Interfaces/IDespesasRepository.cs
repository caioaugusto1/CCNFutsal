using ColaComNois.Context.DB;
using System.Collections.Generic;

namespace ColaComNois.Repository.Interfaces
{
    public interface IDespesasRepository
    {
        public void Ativar(int id);

        IList<ccn_despesas> ObterAtivos();
    }
}
