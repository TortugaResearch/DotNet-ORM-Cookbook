using NHibernate;
using Recipes.NHibernate.Entities;
using Recipes.RowCount;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.NHibernate.RowCount
{
    public class RowCountScenario : IRowCountScenario<Employee>
    {
        readonly ISessionFactory m_SessionFactory;

        public RowCountScenario(ISessionFactory sessionFactory)
        {
            m_SessionFactory = sessionFactory;
        }

        public int EmployeeCount(string lastName)
        {
            using (var session = m_SessionFactory.OpenSession())
                return session.Query<Employee>().Where(e => e.LastName == lastName).Count();
        }

        public int EmployeeCount()
        {
            using (var session = m_SessionFactory.OpenSession())
                return session.Query<Employee>().Count();
        }

        public void InsertBatch(IList<Employee> employees)
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
    }
}
