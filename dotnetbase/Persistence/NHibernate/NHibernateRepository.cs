using System;
using dotnetbase.ExceptionHandling;

namespace dotnetbase.Persistence.NHibernate
{
    public abstract class NHibernateRepository<TEntity> : NHibernateReadOnlyRepository<TEntity>, IRepository<TEntity> where TEntity : class
    {

        protected NHibernateRepository(INHibernateSessionHelper sessionHelper, IExceptionHandler exceptionHandler)
            :base(sessionHelper, exceptionHandler)
        {
        }


        public void Save(TEntity entity)
        {
            try
            {
                var session = _sessionHelper.GetCurrentSession();
                using (var tx = session.BeginTransaction())
                {
                    session.SaveOrUpdate(entity);
                    tx.Commit();
                }
            }
            catch (Exception ex)
            {
                _exceptionHandler.HandleException(ex);
                throw;
            }
        }

        public void Delete(TEntity entity)
        {
            try
            {

                var session = _sessionHelper.GetCurrentSession();
                using (var tx = session.BeginTransaction())
                {
                    session.Delete(entity);
                    tx.Commit();
                }

            }
            catch (Exception ex)
            {
                _exceptionHandler.HandleException(ex);
                throw;
            }
        }
    }
}