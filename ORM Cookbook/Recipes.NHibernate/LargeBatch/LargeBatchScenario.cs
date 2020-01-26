using NHibernate;
using Recipes.LargeBatch;
using Recipes.NHibernate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.NHibernate.LargeBatch
{
    public class LargeBatchScenario : ILargeBatchScenario<Employee>
    {
        readonly ISessionFactory m_SessionFactory;

        public LargeBatchScenario(ISessionFactory sessionFactory)
        {
            m_SessionFactory = sessionFactory;
        }

        public int MaximumBatchSize => int.MaxValue;

        public int CountByLastName(string lastName)
        {
            using (var session = m_SessionFactory.OpenSession())
                return session.Query<Employee>().Where(ec => ec.LastName == lastName).Count();
        }

        public void InsertLargeBatch(IList<Employee> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            using (var session = m_SessionFactory.OpenSession())
            {
                foreach (var employee in employees)
                    session.Save(employee);
                session.Flush();
            }
        }

        public void InsertLargeBatch(IList<Employee> employees, int batchSize)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            foreach (var batch in employees.BatchAsLists(batchSize))
            {
                using (var session = m_SessionFactory.OpenSession())
                {
                    foreach (var employee in batch)
                        session.Save(employee);
                    session.Flush();
                }
            }
        }
    }
}
