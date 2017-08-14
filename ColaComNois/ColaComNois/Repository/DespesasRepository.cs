using System.Collections.Generic;
using ColaComNois.Context;
using ColaComNois.Context.DB;
using System.Linq;
using System;

namespace ColaComNois.Repository
{
    public class DespesasRepository : RepositoryBase<ccn_despesas>
    {
        public DespesasRepository(ColaComNoisContext context)
            : base(context)
        {

        }

        //public override IList<CCN_Despesas> ObterTodos()
        //{
        //    return _context.Despesas.Where(d => d.Data_Vencimento > DateTime.Today.AddDays(Convert.ToDouble(-30)))
        //        .OrderBy(d => d.Status) 
        //        .ThenBy(d => d.Nome).ToList();
        //}
    }
}