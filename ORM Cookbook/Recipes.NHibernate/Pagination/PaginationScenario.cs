using NHibernate;
using Recipes.NHibernate.Entities;
using Recipes.Pagination;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Recipes.NHibernate.Pagination
{
    public class PaginationScenario : IPaginationScenario<Employee>
    {
        readonly ISessionFactory m_SessionFactory;

        public PaginationScenario(ISessionFactory sessionFactory)
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

        public IList<Employee> PaginateWithPageSize(string lastName, int page, int pageSize)
        {
            using (var session = m_SessionFactory.OpenSession())
                return session.Query<Employee>().Where(e => e.LastName == lastName)
                    .OrderBy(e => e.FirstName).ThenBy(e => e.EmployeeKey)
                    .Skip(page * pageSize).Take(pageSize).ToList();
        }

        [SuppressMessage("Globalization", "CA1307")]
        public IList<Employee> PaginateWithSkipPast(string lastName, Employee? skipPast, int take)
        {
            using (var session = m_SessionFactory.OpenSession())
            {
                if (skipPast == null)
                {
                    return session.Query<Employee>().Where(e => e.LastName == lastName)
                        .OrderBy(e => e.FirstName).ThenBy(e => e.EmployeeKey)
                        .Take(take).ToList();
                }
                else
                {
                    return session.Query<Employee>()
                        .Where(e => (e.LastName == lastName) && (
                            (string.Compare(e.FirstName, skipPast.FirstName) > 0)
                                || (e.FirstName == skipPast.FirstName && e.EmployeeKey > skipPast.EmployeeKey))
                            )
                        .OrderBy(e => e.FirstName).ThenBy(e => e.EmployeeKey)
                        .Take(take).ToList();
                }
            }
        }

        public IList<Employee> PaginateWithSkipTake(string lastName, int skip, int take)
        {
            using (var session = m_SessionFactory.OpenSession())
                return session.Query<Employee>().Where(e => e.LastName == lastName)
                    .OrderBy(e => e.FirstName).ThenBy(e => e.EmployeeKey)
                    .Skip(skip).Take(take).ToList();
        }
    }
}
