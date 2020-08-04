using Recipes.Xpo.Entities;
using Recipes.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DevExpress.Xpo;

namespace Recipes.Xpo.Views
{
    public class ViewsScenario : IViewsScenario<EmployeeDetail, Employee>
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
            return Session.DefaultSession.Query<EmployeeDetail>().Where(x => x.EmployeeClassificationKey == employeeClassificationKey).ToList();
        }

        public IList<EmployeeDetail> FindByLastName(string lastName)
        {
            return Session.DefaultSession.Query<EmployeeDetail>().Where(x => x.LastName == lastName).ToList();
        }

        public EmployeeDetail? GetByEmployeeKey(int employeeKey)
        {
            return Session.DefaultSession.Query<EmployeeDetail>().Where(x => x.EmployeeKey == employeeKey).SingleOrDefault();
        }

        public IEmployeeClassification? GetClassification(int employeeClassificationKey)
        {
            return Session.DefaultSession.GetObjectByKey<EmployeeClassification>(employeeClassificationKey);
        }
    }
}
