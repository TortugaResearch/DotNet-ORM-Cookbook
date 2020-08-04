using Recipes.Xpo.Entities;
using Recipes.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Xpo;

namespace Recipes.Xpo.Sorting
{
    public class SortingScenario : ISortingScenario<Employee>
    {

        public void InsertBatch(IList<Employee> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            Session.DefaultSession.Save(employees);
        }

        public IList<Employee> SortByFirstName(string lastName)
        {
            return Session.DefaultSession.Query<Employee>().Where(x => x.LastName == lastName)
                .OrderBy(x => x.FirstName).ToList();
        }

        public IList<Employee> SortByMiddleNameDescFirstName(string lastName)
        {
            return Session.DefaultSession.Query<Employee>().Where(x => x.LastName == lastName)
                .OrderByDescending(x => x.MiddleName).ThenBy(x => x.FirstName).ToList();
        }

        public IList<Employee> SortByMiddleNameFirstName(string lastName)
        {
            return Session.DefaultSession.Query<Employee>().Where(x => x.LastName == lastName)
                .OrderBy(x => x.MiddleName).ThenBy(x => x.FirstName).ToList();
        }
    }
}
