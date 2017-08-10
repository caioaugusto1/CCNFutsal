using System;
using System.Collections.Generic;
using System.Linq;

namespace ColaComNois.Repository.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        IList<TEntity> ObterTodos();
        IList<TEntity> Obter(Func<TEntity, bool> predicate);
        TEntity ObterPorId(int id);
        void Salvar();
        void Adicionar(TEntity obj);
        void Excluir(int id);
        void Editar(TEntity obj);
        void Dispose();
    }
}
