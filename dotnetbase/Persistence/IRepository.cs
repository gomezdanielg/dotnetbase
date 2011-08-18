namespace dotnetbase.Persistence
{
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class
    {

        void Save(TEntity entity);
        void Delete(TEntity entity);

    }
}