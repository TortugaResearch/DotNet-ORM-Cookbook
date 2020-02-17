using LinqToDB;
using Recipes.LinqToDB.Entities;
using Recipes.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Recipes.LinqToDB.Views
{
    public class ViewsScenario : IViewsScenario<EmployeeDetail, Employee>
    {
        public int Create(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

            using (var db = new OrmCookbook())
            {
                return db.InsertWithInt32Identity(employee);
            }
        }

        public IList<EmployeeDetail> FindByEmployeeClassificationKey(int employeeClassificationKey)
        {
            using (var db = new OrmCookbook())
                return db.EmployeeDetail.Where(x => x.EmployeeClassificationKey == employeeClassificationKey).ToList();
        }

        public IList<EmployeeDetail> FindByLastName(string lastName)
        {
            using (var db = new OrmCookbook())
                return db.EmployeeDetail.Where(x => x.LastName == lastName).ToList();
        }

        public EmployeeDetail? GetByEmployeeKey(int employeeKey)
        {
            using (var db = new OrmCookbook())
                return db.EmployeeDetail.Where(x => x.EmployeeKey == employeeKey).SingleOrDefault();
        }

        public IEmployeeClassification? GetClassification(int employeeClassificationKey)
        {
            using (var db = new OrmCookbook())
                return db.EmployeeClassification.Where(x => x.EmployeeClassificationKey == employeeClassificationKey).SingleOrDefault();
        }
    }
}
