using System;
using NHibernate;

namespace dotnetbase.Persistence.NHibernate
{
    public class NHibernateDesktopAppSessionHelper : INHibernateSessionHelper
    {

        private readonly INHibernateSessionFactoryHelper _sessionFactoryHelper;

        private ISession _currentSession;

        public NHibernateDesktopAppSessionHelper(INHibernateSessionFactoryHelper sessionFactoryHelper)
        {
            _sessionFactoryHelper = sessionFactoryHelper;
        }
        
        public IStatelessSession GetStatelessSession()
        {
            return _sessionFactoryHelper.SessionFactory.OpenStatelessSession();
        }

        public ISession GetCurrentSession()
        {
            if (_currentSession == null)
                OpenSession();

            return _currentSession;
        }

        public void OpenSession()
        {
            if (_currentSession != null)
                throw new InvalidOperationException("Ya existe una sesión abierta");

            _currentSession = _sessionFactoryHelper.SessionFactory.OpenSession();
        }

        public void ReOpenSession()
        {
            CloseSession();
            OpenSession();
        }

        public void CloseSession()
        {
            if (_currentSession == null) return;

            _currentSession.Dispose();
            _currentSession = null;
        }
    }
}