using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace AlmocoAPI.Repositories.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        //Achar objetos
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        //Adicionar objetos
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        //Remover objetos
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

    }
}