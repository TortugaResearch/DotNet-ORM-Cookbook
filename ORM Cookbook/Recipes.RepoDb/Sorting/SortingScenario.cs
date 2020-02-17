using Microsoft.Data.SqlClient;
using Recipes.RepoDb.Models;
using Recipes.Sorting;
using RDB = RepoDb;
using RepoDb;
using RepoDb.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.RepoDb.Sorting
{
    public class SortingScenario : BaseRepository<EmployeeSimple, SqlConnection>,
        ISortingScenario<EmployeeSimple>
    {
        public SortingScenario(string connectionString)
            : base(connectionString, RDB.Enumerations.ConnectionPersistency.Instance)
        { }

        public void InsertBatch(IList<EmployeeSimple> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            InsertAll(employees);
        }

        public IList<EmployeeSimple> SortByFirstName(string lastName)
        {
            return Query(x => x.LastName == lastName)
                .OrderBy(x => x.FirstName).AsList();
        }

        public IList<EmployeeSimple> SortByMiddleNameDescFirstName(string lastName)
        {
            return Query(x => x.LastName == lastName)
                .OrderByDescending(x => x.MiddleName).ThenBy(x => x.FirstName).AsList();
        }

        public IList<EmployeeSimple> SortByMiddleNameFirstName(string lastName)
        {
            return Query(x => x.LastName == lastName)
                .OrderBy(x => x.MiddleName).ThenBy(x => x.FirstName).AsList();
        }
    }
}
