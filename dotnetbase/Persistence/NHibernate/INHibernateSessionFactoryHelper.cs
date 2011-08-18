using NHibernate;

namespace dotnetbase.Persistence.NHibernate
{
    public interface INHibernateSessionFactoryHelper
    {
        ISessionFactory SessionFactory { get; }
    }
}