using ColaComNois.Context;
using ColaComNois.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ColaComNois.Repository
{
    public abstract class RepositoryBase<DBEntity> : IDisposable, IRepositoryBase<DBEntity>
        where DBEntity : class
    {
        protected readonly ColaComNoisContext _context;

        protected RepositoryBase(ColaComNoisContext context)
        {
            _context = context;
        }

        public virtual void Adicionar(DBEntity obj)
        {
            _context.Set<DBEntity>().Add(obj);
            Salvar();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual void Editar(DBEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            Salvar();
        }

        public virtual void Excluir(int id)
        {
            _context.Set<DBEntity>().Remove(_context.Set<DBEntity>().Find(id));
            Salvar();
        }

        public virtual IList<DBEntity> Obter(Func<DBEntity, bool> predicate)
        {
            return _context.Set<DBEntity>().ToList();
        }

        public virtual DBEntity ObterPorId(int id)
        {
            return _context.Set<DBEntity>().Find(id);
        }
            
        public virtual IList<DBEntity> ObterTodos()
        {
            return _context.Set<DBEntity>().ToList();
        }

        public virtual void Salvar()
        {
            _context.SaveChanges();
        }

        //public IList<DBEntity> Obt(int t, int s)
        //{
        //    return _context.Set<DBEntity>().Take(t).Skip(s).ToList();
        //}
    }
}