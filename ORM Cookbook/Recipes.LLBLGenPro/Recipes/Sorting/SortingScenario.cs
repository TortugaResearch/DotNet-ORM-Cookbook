using LLBLGenPro.OrmCookbook.DatabaseSpecific;
using LLBLGenPro.OrmCookbook.EntityClasses;
using LLBLGenPro.OrmCookbook.Linq;
using Recipes.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.LLBLGenPro.Sorting
{
    public class SortingScenario : ISortingScenario<EmployeeEntity>
    {
        public int Create(EmployeeEntity employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

            using (var adapter = new DataAccessAdapter())
            {
                adapter.SaveEntity(employee);
                return employee.EmployeeKey;
            }
        }

        public IList<EmployeeEntity> SortByLastName()
        {
            using (var adapter = new DataAccessAdapter())
            {
                return new LinqMetaData(adapter).Employee.OrderBy(x => x.LastName).ToList();
            }
        }

        public IList<EmployeeEntity> SortByLastNameDescFirstName()
        {
            using (var adapter = new DataAccessAdapter())
            {
                return new LinqMetaData(adapter).Employee.OrderByDescending(x => x.LastName).ThenBy(x => x.FirstName).ToList();
            }
        }

        public IList<EmployeeEntity> SortByLastNameFirstName()
        {
            using (var adapter = new DataAccessAdapter())
            {
                return new LinqMetaData(adapter).Employee.OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ToList();
            }
        }
    }
}
