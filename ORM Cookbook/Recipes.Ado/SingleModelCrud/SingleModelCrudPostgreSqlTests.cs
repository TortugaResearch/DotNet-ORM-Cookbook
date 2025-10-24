using Recipes.Ado.Models;
using Recipes.SingleModelCrud;

namespace Recipes.Ado.SingleModelCrud;

[TestClass]
public class SingleModelCrudPostgreSqlTests : SingleModelCrudTests<EmployeeClassification>
{
    protected override ISingleModelCrudScenario<EmployeeClassification> GetScenario()
    {
        return new SingleModelCrudPostgreSqlScenario(Setup.PostgreSqlConnectionString);
    }
}