using Recipes.RepoDb.Entities;
using Recipes.Sorting;
using RepoDb;
using RepoDb.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Recipes.RepoDb.Sorting
{
    public class SortingScenario : BaseRepository<EmployeeSimple, SqlConnection>,
        ISortingScenario<EmployeeSimple>
    {
        public SortingScenario(string connectionString)
            : base(connectionString)
        { }

        public int Create(EmployeeSimple employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

            return Insert<int>(employee);
        }

        public IList<EmployeeSimple> SortByLastName()
        {
            return QueryAll().OrderBy(x => x.LastName).AsList();
        }

        public IList<EmployeeSimple> SortByLastNameFirstName()
        {
            return QueryAll().OrderBy(x => x.LastName).ThenBy(x => x.FirstName).AsList();
        }

        public IList<EmployeeSimple> SortByLastNameDescFirstName()
        {
            return QueryAll().OrderByDescending(x => x.LastName).ThenBy(x => x.FirstName).AsList();
        }
    }
}
