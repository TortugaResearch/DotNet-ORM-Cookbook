using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Sorting;

namespace Recipes.Ado.Sorting
{
    [TestClass]
    public class SortingTests : SortingTests<EmployeeSimple>
    {
        protected override ISortingScenario<EmployeeSimple> GetScenario()
        {
            return new SortingScenario(Setup.ConnectionString);
        }
    }
}
