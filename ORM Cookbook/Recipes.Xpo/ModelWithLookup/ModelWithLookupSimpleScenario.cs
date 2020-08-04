using Recipes.Xpo.Entities;
using Recipes.ModelWithLookup;
using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Xpo;

namespace Recipes.Xpo.ModelWithLookup
{
    public class ModelWithLookupSimpleScenario : IModelWithLookupSimpleScenario<Employee>
    {

        public int Create(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");
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
            Session.DefaultSession.GetObjectByKey<Employee>(employeeKey).Delete();
        }

        public IList<Employee> FindByLastName(string lastName)
        {
            return Session.DefaultSession.Query<Employee>().Where(ec => ec.LastName == lastName).ToList();
        }

        public IList<Employee> GetAll()
        {
            return Session.DefaultSession.Query<Employee>().ToList();
        }

        public Employee? GetByKey(int employeeKey)
        {
            return Session.DefaultSession.GetObjectByKey<Employee>(employeeKey);
        }

        public IEmployeeClassification? GetClassification(int employeeClassificationKey)
        {
            return Session.DefaultSession.GetObjectByKey<EmployeeClassification>(employeeClassificationKey);
        }

        public void Update(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

            employee.Save();
        }
    }
}
