using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.RepoDb.Models;
using Recipes.DynamicSorting;

namespace Recipes.RepoDb.DynamicSorting
{
    [TestClass]
    public class DynamicSortingTests : DynamicSortingTests<EmployeeSimple>
    {
        protected override IDynamicSortingScenario<EmployeeSimple> GetScenario()
        {
            return new DynamicSortingScenario(Setup.ConnectionString);
        }
    }
}
