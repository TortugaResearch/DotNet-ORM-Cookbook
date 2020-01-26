using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.EntityFramework.Entities;
using Recipes.Pagination;

namespace Recipes.EntityFramework.Pagination
{
    [TestClass]
    public class PaginationTests : PaginationTests<Employee>
    {
        protected override IPaginationScenario<Employee> GetScenario()
        {
            return new PaginationScenario(Setup.DBContextFactory);
        }
    }
}
