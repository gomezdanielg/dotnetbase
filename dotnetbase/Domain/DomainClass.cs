using System;
using System.Collections.Generic;
using dotnetbase.ExceptionHandling;
using dotnetbase.Persistence;
using dotnetbase.Validation;

namespace dotnetbase.Domain
{
    public class DomainClass<TEntity>: IDomainClass<TEntity> where TEntity: class, IValidable
    {

        protected readonly IRepository<TEntity> _repository;
        private readonly IExceptionHandler _exceptionHandler;

        public DomainClass(IRepository<TEntity> repository, IExceptionHandler exceptionHandler)
        {
            _repository = repository;
            _exceptionHandler = exceptionHandler;
        }

        public virtual void Save(TEntity entity)
        {
            try
            {
                if (!entity.IsValid())
                    throw new ApplicationException("Validation error");

                _repository.Save(entity);
            }
            catch (Exception ex)
            {
                _exceptionHandler.HandleException(ex);
                throw;
            }
            
        }

        public virtual void Delete(TEntity entity)
        {
            try
            {
                _repository.Delete(entity);
            }
            catch (Exception ex)
            {
                _exceptionHandler.HandleException(ex);
                throw;
            }
            
        }

        public virtual TEntity Find(TEntity entity)
        {
            try
            {
                return _repository.Find(entity);
            }
            catch (Exception ex)
            {
                _exceptionHandler.HandleException(ex);
                throw;
            }
            
        }

        public virtual IList<TEntity> FindAll()
        {
            try
            {
                return _repository.FindAll();
            }
            catch (Exception ex)
            {
                _exceptionHandler.HandleException(ex);
                throw;
            }
        }

    }
}