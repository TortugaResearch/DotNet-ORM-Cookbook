using Recipes.Dapper.Models;
using Recipes.SingleModelCrudAsync;

namespace Recipes.Dapper.SingleModelCrudAsync;

[TestClass]
public class SingleModelCrudAsyncTests : SingleModelCrudAsyncTests<EmployeeClassification>
{
    protected override ISingleModelCrudAsyncScenario<EmployeeClassification> GetScenario()
    {
        return new SingleModelCrudAsyncScenario(Setup.SqlServerConnectionString);
    }
}