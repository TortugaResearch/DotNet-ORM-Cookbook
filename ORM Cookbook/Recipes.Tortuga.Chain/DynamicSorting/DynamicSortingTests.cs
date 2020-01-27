using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Chain.Models;
using Recipes.DynamicSorting;

namespace Recipes.Chain.DynamicSorting
{
    [TestClass]
    public class DynamicSortingTests : DynamicSortingTests<EmployeeSimple>
    {
        protected override IDynamicSortingScenario<EmployeeSimple> GetScenario()
        {
            return new DynamicSortingScenario(Setup.PrimaryDataSource);
        }
    }
}
