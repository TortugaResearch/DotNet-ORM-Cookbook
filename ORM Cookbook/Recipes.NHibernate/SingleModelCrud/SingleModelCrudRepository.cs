using NHibernate;
using NHibernate.Criterion;
using Recipes.NHibernate.Models;
using Recipes.SingleModelCrud;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.NHibernate.SingleModelCrud
{
    public class SingleModelCrudRepository : ISingleModelCrudRepository<EmployeeClassification>
    {
        readonly ISessionFactory m_SessionFactory;

        public SingleModelCrudRepository(ISessionFactory sessionFactory)
        {
            m_SessionFactory = sessionFactory;
        }

        public int Create(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var session = m_SessionFactory.OpenSession())
            {
                session.Save(classification);
                session.Flush();
                return classification.EmployeeClassificationKey;
            }
        }

        public void DeleteByKey(int employeeClassificationKey)
        {
            using (var session = m_SessionFactory.OpenSession())
            {
                var temp = session.Get<EmployeeClassification>(employeeClassificationKey);
                session.Delete(temp);
                session.Flush();
            }
        }

        public void Delete(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var session = m_SessionFactory.OpenSession())
            {
                session.Delete(classification);
                session.Flush();
            }
        }

        public EmployeeClassification FindByName(string employeeClassificationName)
        {
            using (var session = m_SessionFactory.OpenStatelessSession())
            {
                return session
                    .CreateCriteria(typeof(EmployeeClassification))
                    .Add(Restrictions.Eq("EmployeeClassificationName", employeeClassificationName))
                    .List<EmployeeClassification>()
                    .SingleOrDefault();
            }
        }

        public IList<EmployeeClassification> GetAll()
        {
            using (var session = m_SessionFactory.OpenStatelessSession())
            {
                return session
                    .CreateCriteria(typeof(EmployeeClassification))
                    .List<EmployeeClassification>();
            }
        }

        public EmployeeClassification GetByKey(int employeeClassificationKey)
        {
            using (var session = m_SessionFactory.OpenStatelessSession())
                return session.Get<EmployeeClassification>(employeeClassificationKey);
        }

        public void Update(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var session = m_SessionFactory.OpenSession())
            {
                session.Update(classification);
                session.Flush();
            }
        }
    }
}
