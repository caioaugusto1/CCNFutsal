using System;
using System.Collections.Generic;
using ColaComNois.Context;
using ColaComNois.Context.DB;
using ColaComNois.Repository.Interfaces;
using System.Linq;

namespace ColaComNois.Repository
{
    public class DespesasRepository : RepositoryBase<ccn_despesas>, IDespesasRepository
    {
        public DespesasRepository(ColaComNoisContext context)
            : base(context)
        {

        }

        public IList<ccn_despesas> ObterAtivos()
        {
            return ObterTodos().Where(d => d.Ativo);
        }

        public void Ativar(int id)
        {
            var e = _context.Despesas.Where(d => d.Id == id).FirstOrDefault();
            e.Ativo = false;
            Salvar();
        }
    }
}