using LinqToDB;
using Recipes.LinqToDB.Entities;
using Recipes.RowCount;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.LinqToDB.RowCount
{
    public class RowCountScenario : IRowCountScenario<Employee>
    {
        public int EmployeeCount(string lastName)
        {
            using (var db = new OrmCookbook())
                return db.Employee.Where(e => e.LastName == lastName).Count();
        }

        public int EmployeeCount()
        {
            using (var db = new OrmCookbook())
                return db.Employee.Count();
        }

        public void InsertBatch(IList<Employee> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            using (var db = new OrmCookbook())
            {
                foreach (var employee in employees)
                    db.Insert(employee);
            }
        }
    }
}
