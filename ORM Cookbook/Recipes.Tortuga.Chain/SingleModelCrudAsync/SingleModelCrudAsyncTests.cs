using Recipes.Chain.Models;
using Recipes.SingleModelCrudAsync;

namespace Recipes.Chain.SingleModelCrudAsync;

[TestClass]
public class SingleModelCrudAsyncTests : SingleModelCrudAsyncTests<EmployeeClassification>
{
    protected override ISingleModelCrudAsyncScenario<EmployeeClassification> GetScenario()
    {
        return new SingleModelCrudAsyncScenario(Setup.PrimaryDataSource);
    }
}