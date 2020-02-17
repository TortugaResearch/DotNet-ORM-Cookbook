using NHibernate;
using Recipes.NHibernate.Entities;
using Recipes.Views;
using System;
using System.Collections.Generic;

namespace Recipes.NHibernate.Views
{
    public class ViewsScenario : IViewsScenario<EmployeeDetail, Employee>
    {
        readonly ISessionFactory m_SessionFactory;

        public ViewsScenario(ISessionFactory sessionFactory)
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

        public IList<EmployeeDetail> FindByEmployeeClassificationKey(int employeeClassificationKey)
        {
            using (var session = m_SessionFactory.OpenStatelessSession())
            {
                return session.QueryOver<EmployeeDetail>()
                    .Where(ed => ed.EmployeeClassificationKey == employeeClassificationKey)
                    .List();
            }
        }

        public IList<EmployeeDetail> FindByLastName(string lastName)
        {
            using (var session = m_SessionFactory.OpenStatelessSession())
            {
                return session.QueryOver<EmployeeDetail>().Where(ed => ed.LastName == lastName).List();
            }
        }

        public EmployeeDetail? GetByEmployeeKey(int employeeKey)
        {
            using (var session = m_SessionFactory.OpenStatelessSession())
                return session.Get<EmployeeDetail>(employeeKey);
        }

        public IEmployeeClassification? GetClassification(int employeeClassificationKey)
        {
            using (var session = m_SessionFactory.OpenStatelessSession())
                return session.Get<EmployeeClassification>(employeeClassificationKey);
        }
    }
}
