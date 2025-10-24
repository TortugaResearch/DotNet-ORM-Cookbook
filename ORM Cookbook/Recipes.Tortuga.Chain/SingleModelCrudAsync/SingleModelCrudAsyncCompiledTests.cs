using Recipes.Chain.Models;
using Recipes.SingleModelCrudAsync;

namespace Recipes.Chain.SingleModelCrudAsync;

[TestClass]
public class SingleModelCrudAsyncCompiledTests : SingleModelCrudAsyncTests<EmployeeClassification>
{
    protected override ISingleModelCrudAsyncScenario<EmployeeClassification> GetScenario()
    {
        return new SingleModelCrudAsyncCompiledScenario(Setup.PrimaryDataSource);
    }
}