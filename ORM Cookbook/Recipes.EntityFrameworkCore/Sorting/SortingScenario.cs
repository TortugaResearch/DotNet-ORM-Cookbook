using Recipes.EntityFrameworkCore.Entities;
using Recipes.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.EntityFrameworkCore.Sorting
{
    public class SortingScenario : ISortingScenario<Employee>
    {
        private Func<OrmCookbookContext> CreateDbContext;

        public SortingScenario(Func<OrmCookbookContext> dBContextFactory)
        {
            CreateDbContext = dBContextFactory;
        }

        public void InsertBatch(IList<Employee> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            using (var context = CreateDbContext())
            {
                foreach (var employee in employees)
                    context.Employee.Add(employee);
                context.SaveChanges();
            }
        }

        public IList<Employee> SortByFirstName(string lastName)
        {
            using (var context = CreateDbContext())
                return context.Employee.Where(x => x.LastName == lastName)
                    .OrderBy(x => x.FirstName).ToList();
        }

        public IList<Employee> SortByMiddleNameDescFirstName(string lastName)
        {
            using (var context = CreateDbContext())
                return context.Employee.Where(x => x.LastName == lastName)
                    .OrderByDescending(x => x.MiddleName).ThenBy(x => x.FirstName).ToList();
        }

        public IList<Employee> SortByMiddleNameFirstName(string lastName)
        {
            using (var context = CreateDbContext())
                return context.Employee.Where(x => x.LastName == lastName)
                    .OrderBy(x => x.MiddleName).ThenBy(x => x.FirstName).ToList();
        }
    }
}
