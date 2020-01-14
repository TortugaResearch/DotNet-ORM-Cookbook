using NHibernate;
using Recipes.NHibernate.Entities;
using Recipes.Sorting;
using System;
using System.Collections.Generic;

namespace Recipes.NHibernate.Sorting
{
    public class SortingRepository : ISortingRepository<Employee>
    {
        readonly ISessionFactory m_SessionFactory;

        public SortingRepository(ISessionFactory sessionFactory)
        {
            m_SessionFactory = sessionFactory;
        }

        public int Create(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

            using (var session = m_SessionFactory.OpenSession())
            {
                session.Save(employee);
                session.Flush();
                return employee.EmployeeKey;
            }
        }

        public IList<Employee> SortByLastName()
        {
            using (var session = m_SessionFactory.OpenStatelessSession())
            {
                return session
                    .QueryOver<Employee>()
                    .OrderBy(x => x.LastName).Asc
                    .List();
            }
        }

        public IList<Employee> SortByLastNameDescFirstName()
        {
            using (var session = m_SessionFactory.OpenStatelessSession())
            {
                return session
                    .QueryOver<Employee>()
                    .OrderBy(x => x.LastName).Desc
                    .ThenBy(x => x.FirstName).Asc
                    .List();
            }
        }

        public IList<Employee> SortByLastNameFirstName()
        {
            using (var session = m_SessionFactory.OpenStatelessSession())
            {
                return session
                    .QueryOver<Employee>()
                    .OrderBy(x => x.LastName).Asc
                    .ThenBy(x => x.FirstName).Asc
                    .List();
            }
        }
    }
}
