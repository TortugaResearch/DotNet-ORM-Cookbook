using NHibernate;
using Recipes.NHibernate.Entities;
using Recipes.SingleModelCrud;
using System;
using System.Collections.Generic;

namespace Recipes.NHibernate.SingleModelCrud
{
    public class SingleModelCrudScenario : ISingleModelCrudScenario<EmployeeClassification>
    {
        readonly ISessionFactory m_SessionFactory;

        public SingleModelCrudScenario(ISessionFactory sessionFactory)
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

        public void DeleteByKey(int employeeClassificationKey)
        {
            using (var session = m_SessionFactory.OpenSession())
            {
                session.Delete(new EmployeeClassification() { EmployeeClassificationKey = employeeClassificationKey });
                session.Flush();
            }
        }

        public EmployeeClassification FindByName(string employeeClassificationName)
        {
            using (var session = m_SessionFactory.OpenStatelessSession())
            {
                return session.QueryOver<EmployeeClassification>().Where(ec => ec.EmployeeClassificationName == employeeClassificationName).SingleOrDefault();
            }
        }

        public IList<EmployeeClassification> GetAll()
        {
            using (var session = m_SessionFactory.OpenStatelessSession())
            {
                return session.QueryOver<EmployeeClassification>().List();
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
