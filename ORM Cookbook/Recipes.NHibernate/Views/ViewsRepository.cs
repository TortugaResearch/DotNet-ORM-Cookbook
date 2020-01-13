using Recipes.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NHibernate;
using NHibernate.Criterion;
using Recipes.NHibernate.Entities;

namespace Recipes.NHibernate.Views
{
    public class ViewsRepository : IViewsRepository<EmployeeDetail, Employee>
    {
        readonly ISessionFactory m_SessionFactory;

        public ViewsRepository(ISessionFactory sessionFactory)
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
                return session
                    .CreateCriteria(typeof(EmployeeDetail))
                    .Add(Restrictions.Eq("EmployeeClassificationKey", employeeClassificationKey))
                    .List<EmployeeDetail>();
            }
        }

        public IList<EmployeeDetail> FindByLastName(string lastName)
        {
            using (var session = m_SessionFactory.OpenStatelessSession())
            {
                return session
                    .CreateCriteria(typeof(EmployeeDetail))
                    .Add(Restrictions.Eq("LastName", lastName))
                    .List<EmployeeDetail>();
            }
        }

        public IList<EmployeeDetail> GetAll()
        {
            using (var session = m_SessionFactory.OpenStatelessSession())
            {
                return session
                    .CreateCriteria(typeof(EmployeeDetail))
                    .List<EmployeeDetail>();
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
