using Recipes.Chain.Models;
using Recipes.SoftDelete;

namespace Recipes.Chain.SoftDelete;

[TestClass]
public class SoftDeleteTests : SoftDeleteTests<Department>
{
    protected override ISoftDeleteScenario<Department> GetScenario()
    {
        return new SoftDeleteScenario(Setup.PrimaryDataSource);
    }
}