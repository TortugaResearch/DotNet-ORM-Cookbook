using NHibernate;
using Recipes.NHibernate.Entities;
using Recipes.Sorting;
using System;
using System.Collections.Generic;

namespace Recipes.NHibernate.Sorting
{
    public class SortingScenario : ISortingScenario<Employee>
    {
        readonly ISessionFactory m_SessionFactory;

        public SortingScenario(ISessionFactory sessionFactory)
        {
            m_SessionFactory = sessionFactory;
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

        public IList<Employee> SortByFirstName(string lastName)
        {
            using (var session = m_SessionFactory.OpenStatelessSession())
            {
                return session.QueryOver<Employee>().Where(x => x.LastName == lastName)
                    .OrderBy(x => x.FirstName).Asc
                    .List();
            }
        }

        public IList<Employee> SortByMiddleNameDescFirstName(string lastName)
        {
            using (var session = m_SessionFactory.OpenStatelessSession())
            {
                return session.QueryOver<Employee>().Where(x => x.LastName == lastName)
                    .OrderBy(x => x.MiddleName).Desc.ThenBy(x => x.FirstName).Asc
                    .List();
            }
        }

        public IList<Employee> SortByMiddleNameFirstName(string lastName)
        {
            using (var session = m_SessionFactory.OpenStatelessSession())
            {
                return session.QueryOver<Employee>().Where(x => x.LastName == lastName)
                    .OrderBy(x => x.MiddleName).Asc.ThenBy(x => x.FirstName).Asc
                    .List();
            }
        }
    }
}
