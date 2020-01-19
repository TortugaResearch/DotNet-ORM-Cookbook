using LinqToDB;
using Recipes.LinqToDB.Entities;
using Recipes.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.LinqToDB.Sorting
{
    public class SortingScenario : ISortingScenario<Employee>
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

        public IList<Employee> SortByLastName()
        {
            using (var db = new OrmCookbook())
                return db.Employee.OrderBy(x => x.LastName).ToList();
        }

        public IList<Employee> SortByLastNameDescFirstName()
        {
            using (var db = new OrmCookbook())
                return db.Employee.OrderByDescending(x => x.LastName).ThenBy(x => x.FirstName).ToList();
        }

        public IList<Employee> SortByLastNameFirstName()
        {
            using (var db = new OrmCookbook())
                return db.Employee.OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ToList();
        }
    }
}
