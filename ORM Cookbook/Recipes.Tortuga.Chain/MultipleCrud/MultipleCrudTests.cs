using Recipes.Chain.Models;
using Recipes.MultipleCrud;

namespace Recipes.Chain.MultipleCrud;

[TestClass]
public class MultipleCrudTests : MultipleCrudTests<EmployeeSimple>
{
    protected override IMultipleCrudScenario<EmployeeSimple> GetScenario()
    {
        return new MultipleCrudScenario(Setup.PrimaryDataSource);
    }
}