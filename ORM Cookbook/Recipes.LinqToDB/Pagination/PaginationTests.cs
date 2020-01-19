using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.LinqToDB.Entities;
using Recipes.Pagination;

namespace Recipes.LinqToDB.Pagination
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
