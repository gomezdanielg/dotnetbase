using System.Collections.Generic;

namespace dotnetbase.Domain
{
    public interface IDomainClass<TEntity> where TEntity: class
    {

        void Save(TEntity entity);
        void Delete(TEntity entity);
        TEntity Find(TEntity entity);
        IList<TEntity> FindAll();

    }
}