using Recipes.Chain.Models;
using Recipes.Sorting;

namespace Recipes.Chain.Sorting;

[TestClass]
public class SortingTests : SortingTests<EmployeeSimple>
{
    protected override ISortingScenario<EmployeeSimple> GetScenario()
    {
        return new SortingScenario(Setup.PrimaryDataSource);
    }
}