using Recipes.Xpo.Entities;
using Recipes.Joins;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DevExpress.Xpo;

namespace Recipes.Xpo.Joins
{
    public class JoinsScenario : IJoinsScenario<EmployeeDetail, Employee>
    {
        public int Create(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");
            employee.Save();
            return employee.EmployeeKey;
        }
        public IList<EmployeeDetail> FindByEmployeeClassificationKey(int employeeClassificationKey)
        {
            return Session.DefaultSession.Query<Employee>()
                .Join(Session.DefaultSession.Query<EmployeeClassification>(),
                    e => e.EmployeeClassificationKey,
                    ec => ec.EmployeeClassificationKey,
                    (e, ec) => new EmployeeDetail()
                    {
                        EmployeeKey = e.EmployeeKey,
                        FirstName = e.FirstName,
                        MiddleName = e.MiddleName,
                        LastName = e.LastName,
                        CellPhone = e.CellPhone,
                        OfficePhone = e.OfficePhone,
                        Title = e.Title,
                        EmployeeClassificationKey = ec.EmployeeClassificationKey,
                        EmployeeClassificationName = ec.EmployeeClassificationName,
                        IsEmployee = ec.IsEmployee,
                        IsExempt = ec.IsExempt,
                    })
                .Where(ed => ed.EmployeeClassificationKey == employeeClassificationKey)
                .ToList();
        }


        public IList<EmployeeDetail> FindByLastName(string lastName)
        {
            return Session.DefaultSession.Query<Employee>()
                .Join(Session.DefaultSession.Query<EmployeeClassification>(),
                    e => e.EmployeeClassificationKey,
                    ec => ec.EmployeeClassificationKey,
                    (e, ec) => new EmployeeDetail()
                    {
                        EmployeeKey = e.EmployeeKey,
                        FirstName = e.FirstName,
                        MiddleName = e.MiddleName,
                        LastName = e.LastName,
                        CellPhone = e.CellPhone,
                        OfficePhone = e.OfficePhone,
                        Title = e.Title,
                        EmployeeClassificationKey = ec.EmployeeClassificationKey,
                        EmployeeClassificationName = ec.EmployeeClassificationName,
                        IsEmployee = ec.IsEmployee,
                        IsExempt = ec.IsExempt,
                    })
                .Where(ed => ed.LastName == lastName)
                .ToList();
        }

        public EmployeeDetail? GetByEmployeeKey(int employeeKey)
        {
            return Session.DefaultSession.Query<Employee>()
                .Join(Session.DefaultSession.Query<EmployeeClassification>(),
                    e => e.EmployeeClassificationKey,
                    ec => ec.EmployeeClassificationKey,
                    (e, ec) => new EmployeeDetail()
                    {
                        EmployeeKey = e.EmployeeKey,
                        FirstName = e.FirstName,
                        MiddleName = e.MiddleName,
                        LastName = e.LastName,
                        CellPhone = e.CellPhone,
                        OfficePhone = e.OfficePhone,
                        Title = e.Title,
                        EmployeeClassificationKey = ec.EmployeeClassificationKey,
                        EmployeeClassificationName = ec.EmployeeClassificationName,
                        IsEmployee = ec.IsEmployee,
                        IsExempt = ec.IsExempt,
                    })
                .Where(x => x.EmployeeKey == employeeKey).SingleOrDefault();
        }

        public IEmployeeClassification? GetClassification(int employeeClassificationKey)
        {
            return Session.DefaultSession.GetObjectByKey<EmployeeClassification>(employeeClassificationKey);
        }
    }
}
