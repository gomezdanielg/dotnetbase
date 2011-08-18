using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using dotnetbase.ExceptionHandling;

namespace dotnetbase.Persistence.NHibernate
{
    public abstract class NHibernateReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class
    {

        protected readonly INHibernateSessionHelper _sessionHelper;
        protected readonly IExceptionHandler _exceptionHandler;

        protected NHibernateReadOnlyRepository(INHibernateSessionHelper sessionHelper, IExceptionHandler exceptionHandler)
        {
            _sessionHelper = sessionHelper;
            _exceptionHandler = exceptionHandler;
        }

        public TEntity Find(TEntity entity)
        {
            try
            {
                return _sessionHelper.GetCurrentSession().QueryOver<TEntity>().Where(FindExpression(entity)).SingleOrDefault();
            }
            catch (Exception ex)
            {
                _exceptionHandler.HandleException(ex);
                throw;
            }
            
        }

        public IList<TEntity> FindAll()
        {
            try
            {
                return _sessionHelper.GetCurrentSession().QueryOver<TEntity>().List();
            }
            catch (Exception ex)
            {
                _exceptionHandler.HandleException(ex);
                throw;
            }
        }

        public IList<TEntity> FindByCondition(TEntity entity, Expression<Func<TEntity, bool>> condition)
        {
            try
            {
                return _sessionHelper.GetCurrentSession().QueryOver<TEntity>().Where(condition).List();
            }
            catch (Exception ex)
            {
                _exceptionHandler.HandleException(ex);
                throw;
            }
        }

        protected abstract Expression<Func<TEntity, bool>> FindExpression(TEntity entity);
    }
}