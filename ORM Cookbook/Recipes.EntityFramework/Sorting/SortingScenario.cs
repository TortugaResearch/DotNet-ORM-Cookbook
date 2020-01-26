using Recipes.EntityFramework.Entities;
using Recipes.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.EntityFramework.Sorting
{
    public class SortingScenario : ISortingScenario<Employee>
    {
        private Func<OrmCookbookContext> CreateDbContext;

        public SortingScenario(Func<OrmCookbookContext> dBContextFactory)
        {
            CreateDbContext = dBContextFactory;
        }

        public int Create(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

            using (var context = CreateDbContext())
            {
                context.Employee.Add(employee);
                context.SaveChanges();
                return employee.EmployeeKey;
            }
        }

        public IList<Employee> SortByLastName()
        {
            using (var context = CreateDbContext())
                return context.Employee.OrderBy(x => x.LastName).ToList();
        }

        public IList<Employee> SortByLastNameDescFirstName()
        {
            using (var context = CreateDbContext())
                return context.Employee.OrderByDescending(x => x.LastName).ThenBy(x => x.FirstName).ToList();
        }

        public IList<Employee> SortByLastNameFirstName()
        {
            using (var context = CreateDbContext())
                return context.Employee.OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ToList();
        }
    }
}
