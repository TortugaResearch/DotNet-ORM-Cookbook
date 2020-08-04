using Recipes.Xpo.Entities;
using Recipes.ModelWithLookup;
using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Xpo;

namespace Recipes.Xpo.ModelWithLookup
{
    public class ModelWithLookupComplexScenario : IModelWithLookupComplexScenario<Employee>
    {

        public int Create(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");
            if (employee.EmployeeClassification == null)
                throw new ArgumentNullException(nameof(employee), $"{nameof(employee.EmployeeClassification)} is null.");

            employee.EmployeeClassification.Reload();
            employee.Save();
            return employee.EmployeeKey;
        }

        public void Delete(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

            employee.Delete();
        }

        public void DeleteByKey(int employeeKey)
        {
            using (var uow = new UnitOfWork())
            {
                uow.GetObjectByKey<Employee>(employeeKey).Delete();
                uow.CommitChanges();
            }
        }

        public IList<Employee> FindByLastName(string lastName)
        {
            return Session.DefaultSession.Query<Employee>()
                .Where(ec => ec.LastName == lastName)
                .ToList();
        }

        public IList<Employee> GetAll()
        {
            return Session.DefaultSession.Query<Employee>()
                .ToList();
        }

        public Employee? GetByKey(int employeeKey)
        {
            return Session.DefaultSession.Query<Employee>()
                .SingleOrDefault(e => e.EmployeeKey == employeeKey);
        }

        public IEmployeeClassification? GetClassification(int employeeClassificationKey)
        {
            return Session.DefaultSession.GetObjectByKey<EmployeeClassification>(employeeClassificationKey);
        }

        public void Update(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");
            if (employee.EmployeeClassification == null)
                throw new ArgumentNullException(nameof(employee), $"{nameof(employee.EmployeeClassification)} is null.");

            employee.EmployeeClassification.Reload();
            employee.Save();
        }
    }
}
