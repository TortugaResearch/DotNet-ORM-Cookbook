using Recipes.DbConnector.Models;
using Recipes.SingleModelCrud;

namespace Recipes.DbConnector.SingleModelCrud;

[TestClass]
public class SingleModelCrudTests : SingleModelCrudTests<EmployeeClassification>
{
    protected override ISingleModelCrudScenario<EmployeeClassification> GetScenario()
    {
        return new SingleModelCrudScenario(Setup.SqlServerConnectionString);
    }
}