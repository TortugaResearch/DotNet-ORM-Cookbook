using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.RepoDb.Models;
using Recipes.Pagination;

namespace Recipes.RepoDb.Pagination
{
    [TestClass]
    public class PaginationTests : PaginationTests<EmployeeSimple>
    {
        protected override IPaginationScenario<EmployeeSimple> GetScenario()
        {
            return new PaginationScenario(Setup.ConnectionString);
        }
    }
}
