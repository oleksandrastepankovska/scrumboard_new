using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TaskBoard.Infrastructure.Abstract
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Create(TEntity entity);
        TEntity GetSingle(Expression<Func<TEntity, bool>> criteria, params Expression<Func<TEntity, object>>[] includes);
        IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> criteria, params Expression<Func<TEntity, object>>[] includes);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);

        void SaveChanges();
    }
}
