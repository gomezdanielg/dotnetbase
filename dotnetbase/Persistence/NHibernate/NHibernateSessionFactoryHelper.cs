using NHibernate;
using NHibernate.Cfg;

namespace dotnetbase.Persistence.NHibernate
{
    public class NHibernateSessionFactoryHelper : INHibernateSessionFactoryHelper
    {

        public NHibernateSessionFactoryHelper()
        {
            Configure();
        }

        private void Configure()
        {
            var config = new Configuration();
            config.Configure();

            SessionFactory = config.BuildSessionFactory();
        }

        public ISessionFactory SessionFactory { get; private set; }
    }
}