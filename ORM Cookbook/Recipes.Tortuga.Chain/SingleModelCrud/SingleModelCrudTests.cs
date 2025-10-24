using Recipes.Chain.Models;
using Recipes.SingleModelCrud;

namespace Recipes.Chain.SingleModelCrud;

[TestClass]
public class SingleModelCrudTests : SingleModelCrudTests<EmployeeClassification>
{
    protected override ISingleModelCrudScenario<EmployeeClassification> GetScenario()
    {
        return new SingleModelCrudScenario(Setup.PrimaryDataSource);
    }
}