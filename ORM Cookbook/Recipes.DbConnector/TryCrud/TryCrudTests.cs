using Recipes.DbConnector.Models;
using Recipes.TryCrud;

namespace Recipes.DbConnector.TryCrud;

[TestClass]
public class TryCrudTests : TryCrudTests<EmployeeClassification>
{
    protected override ITryCrudScenario<EmployeeClassification> GetScenario()
    {
        return new TryCrudScenario(Setup.SqlServerConnectionString);
    }
}