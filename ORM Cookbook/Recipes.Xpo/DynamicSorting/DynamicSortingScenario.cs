using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using Recipes.DynamicSorting;
using Recipes.Xpo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.Xpo.DynamicSorting
{
    public class DynamicSortingScenario : IDynamicSortingScenario<Employee>
    {

        public void InsertBatch(IList<Employee> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            Session.DefaultSession.Save(employees);
        }

        public IList<Employee> SortBy(string lastName, string sortByColumn, bool isDescending)
        {
            return Session.DefaultSession.Query<Employee>().Where(x => x.LastName == lastName)
                   .OrderBy(sortByColumn, isDescending).ToList();
        }

        public IList<Employee> SortBy(string lastName, string sortByColumnA, bool isDescendingA,
            string sortByColumnB, bool isDescendingB)
        {

            return new XPCollection<Employee>(
                CriteriaOperator.Parse("[LastName] = ?", lastName),
                new SortProperty(sortByColumnA, isDescendingA ? DevExpress.Xpo.DB.SortingDirection.Descending : DevExpress.Xpo.DB.SortingDirection.Ascending),
                new SortProperty(sortByColumnB, isDescendingB ? DevExpress.Xpo.DB.SortingDirection.Descending : DevExpress.Xpo.DB.SortingDirection.Ascending));

            //// You can also use the DynamicSortingExtensions applied to Linq to XPO Query
            //return Session.DefaultSession.Query<Employee>().Where(x => x.LastName == lastName)
            //    .OrderBy(sortByColumnA, isDescendingA)
            //    .ThenBy(sortByColumnB, isDescendingB)
            //    .ToList();
        }
    }
}
