using Recipes.RepoDB.Models;
using Recipes.TryCrud;

namespace Recipes.RepoDB.TryCrud;

[TestClass]
public class TryCrudTests : TryCrudTests<EmployeeClassification>
{
    protected override ITryCrudScenario<EmployeeClassification> GetScenario()
    {
        return new TryCrudScenario(Setup.ConnectionString);
    }
}