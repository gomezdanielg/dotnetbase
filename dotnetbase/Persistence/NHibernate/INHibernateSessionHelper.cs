using NHibernate;

namespace dotnetbase.Persistence.NHibernate
{
    public interface INHibernateSessionHelper
    {

        ISession GetCurrentSession();
        void OpenSession();
        void ReOpenSession();
        void CloseSession();

    }
}