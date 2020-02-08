using NHibernate;
using Recipes.Joins;
using Recipes.NHibernate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.NHibernate.Joins
{
    public class JoinsScenario : IJoinsScenario<EmployeeDetail, Employee>
    {
        readonly ISessionFactory m_SessionFactory;

        public JoinsScenario(ISessionFactory sessionFactory)
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
                return session.QueryOver<EmployeeComplex>()
                    .JoinQueryOver(e => e.EmployeeClassification)
                    .Where(ec => ec!.EmployeeClassificationKey == employeeClassificationKey)
                    .List()
                    .Select(e => new EmployeeDetail()
                    {
                        EmployeeKey = e.EmployeeKey,
                        FirstName = e.FirstName,
                        MiddleName = e.MiddleName,
                        LastName = e.LastName,
                        CellPhone = e.CellPhone,
                        OfficePhone = e.OfficePhone,
                        Title = e.Title,
                        EmployeeClassificationKey = e.EmployeeClassification!.EmployeeClassificationKey,
                        EmployeeClassificationName = e.EmployeeClassification.EmployeeClassificationName,
                        IsEmployee = e.EmployeeClassification.IsEmployee,
                        IsExempt = e.EmployeeClassification.IsExempt,
                    })
                    .ToList();
            }
        }

        public IList<EmployeeDetail> FindByLastName(string lastName)
        {
            using (var session = m_SessionFactory.OpenStatelessSession())
            {
                return session.QueryOver<EmployeeComplex>()
                    .Where(e => e.LastName == lastName)
                    .JoinQueryOver(e => e.EmployeeClassification)
                    .List()
                    .Select(e => new EmployeeDetail()
                    {
                        EmployeeKey = e.EmployeeKey,
                        FirstName = e.FirstName,
                        MiddleName = e.MiddleName,
                        LastName = e.LastName,
                        CellPhone = e.CellPhone,
                        OfficePhone = e.OfficePhone,
                        Title = e.Title,
                        EmployeeClassificationKey = e.EmployeeClassification!.EmployeeClassificationKey,
                        EmployeeClassificationName = e.EmployeeClassification.EmployeeClassificationName,
                        IsEmployee = e.EmployeeClassification.IsEmployee,
                        IsExempt = e.EmployeeClassification.IsExempt,
                    })
                    .ToList();
            }
        }

        public EmployeeDetail? GetByEmployeeKey(int employeeKey)
        {
            using (var session = m_SessionFactory.OpenStatelessSession())
                return session.QueryOver<EmployeeComplex>()
                    .Where(e => e.EmployeeKey == employeeKey)
                    .JoinQueryOver(e => e.EmployeeClassification)
                    .List()
                    .Select(e => new EmployeeDetail()
                    {
                        EmployeeKey = e.EmployeeKey,
                        FirstName = e.FirstName,
                        MiddleName = e.MiddleName,
                        LastName = e.LastName,
                        CellPhone = e.CellPhone,
                        OfficePhone = e.OfficePhone,
                        Title = e.Title,
                        EmployeeClassificationKey = e.EmployeeClassification!.EmployeeClassificationKey,
                        EmployeeClassificationName = e.EmployeeClassification.EmployeeClassificationName,
                        IsEmployee = e.EmployeeClassification.IsEmployee,
                        IsExempt = e.EmployeeClassification.IsExempt,
                    })
                    .SingleOrDefault();
        }

        public IEmployeeClassification? GetClassification(int employeeClassificationKey)
        {
            using (var session = m_SessionFactory.OpenStatelessSession())
                return session.Get<EmployeeClassification>(employeeClassificationKey);
        }
    }
}
