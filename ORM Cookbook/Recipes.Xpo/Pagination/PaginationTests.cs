using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Xpo.Entities;
using Recipes.Pagination;

namespace Recipes.Xpo.Pagination
{
    [TestClass]
    public class PaginationTests : PaginationTests<Employee>
    {
        protected override IPaginationScenario<Employee> GetScenario()
        {
            return new PaginationScenario();
        }
    }
}
