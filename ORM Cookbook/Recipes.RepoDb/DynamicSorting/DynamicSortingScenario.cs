using Microsoft.Data.SqlClient;
using Recipes.DynamicSorting;
using Recipes.RepoDb.Models;
using RepoDb;
using RepoDb.Enumerations;
using RepoDb.Extensions;
using System;
using System.Collections.Generic;

namespace Recipes.RepoDb.DynamicSorting
{
    public class DynamicSortingScenario : BaseRepository<EmployeeSimple, SqlConnection>,
        IDynamicSortingScenario<EmployeeSimple>
    {
        public DynamicSortingScenario(string connectionString)
            : base(connectionString, ConnectionPersistency.Instance)
        { }

        public void InsertBatch(IList<EmployeeSimple> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            InsertAll(employees);
        }

        public IList<EmployeeSimple> SortBy(string lastName, string sortByColumn, bool isDescending)
        {
            var sort = new[] { new OrderField(sortByColumn, isDescending ? Order.Descending : Order.Ascending) };
            return Query(x => x.LastName == lastName, orderBy: sort).AsList();
        }

        public IList<EmployeeSimple> SortBy(string lastName, string sortByColumnA, bool isDescendingA, string sortByColumnB, bool isDescendingB)
        {
            var sort = new[] {
                new OrderField(sortByColumnA, isDescendingA ? Order.Descending : Order.Ascending),
                new OrderField(sortByColumnB, isDescendingB ? Order.Descending : Order.Ascending)
            };
            return Query(x => x.LastName == lastName, orderBy: sort).AsList();
        }
    }
}
