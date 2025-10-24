using Recipes.DbConnector.Models;
using Recipes.SingleModelCrudAsync;

namespace Recipes.DbConnector.SingleModelCrudAsync;

[TestClass]
public class SingleModelCrudAsyncTests : SingleModelCrudAsyncTests<EmployeeClassification>
{
    protected override ISingleModelCrudAsyncScenario<EmployeeClassification> GetScenario()
    {
        return new SingleModelCrudAsyncScenario(Setup.SqlServerConnectionString);
    }
}