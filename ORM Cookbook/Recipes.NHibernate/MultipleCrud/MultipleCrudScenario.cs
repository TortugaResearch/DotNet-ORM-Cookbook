using NHibernate;
using Recipes.MultipleCrud;
using Recipes.NHibernate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.NHibernate.MultipleCrud
{
    public class MultipleCrudScenario : IMultipleCrudScenario<Employee>
    {
        readonly ISessionFactory m_SessionFactory;

        public MultipleCrudScenario(ISessionFactory sessionFactory)
        {
            m_SessionFactory = sessionFactory;
        }

        public void DeleteBatch(IList<Employee> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            using (var session = m_SessionFactory.OpenSession())
            {
                foreach (var employee in employees)
                    session.Delete(employee);
                session.Flush();
            }
        }

        public void DeleteBatchByKey(IList<int> employeeKeys)
        {
            if (employeeKeys == null || employeeKeys.Count == 0)
                throw new ArgumentException($"{nameof(employeeKeys)} is null or empty.", nameof(employeeKeys));

            using (var session = m_SessionFactory.OpenSession())
            {
                foreach (var key in employeeKeys)
                    session.Delete(new Employee() { EmployeeKey = key });

                session.Flush();
            }
        }

        public IList<Employee> FindByLastName(string lastName)
        {
            using (var session = m_SessionFactory.OpenSession())
                return session.Query<Employee>().Where(ec => ec.LastName == lastName).ToList();
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

        public IList<int> InsertBatchReturnKeys(IList<Employee> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            using (var session = m_SessionFactory.OpenSession())
            {
                foreach (var employee in employees)
                    session.Save(employee);
                session.Flush();
            }

            return employees.Select(x => x.EmployeeKey).ToList();
        }

        public IList<Employee> InsertBatchReturnRows(IList<Employee> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            using (var session = m_SessionFactory.OpenSession())
            {
                foreach (var employee in employees)
                    session.Save(employee);
                session.Flush();
            }

            return employees;
        }

        public void InsertBatchWithRefresh(IList<Employee> employees)
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

        public void UpdateBatch(IList<Employee> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            using (var session = m_SessionFactory.OpenSession())
            {
                foreach (var employee in employees)
                    session.Update(employee);
                session.Flush();
            }
        }
    }
}
