using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace dotnetbase.Persistence
{
    public interface IReadOnlyRepository<TEntity> where TEntity : class
    {

        TEntity Find(TEntity entity);
        IList<TEntity> FindAll();
        IList<TEntity> FindByCondition(TEntity entity, Expression<Func<TEntity, bool>> condition);


    }
}