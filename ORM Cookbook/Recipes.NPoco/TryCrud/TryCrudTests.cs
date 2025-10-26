using Recipes.NPoco.Models;
using Recipes.TryCrud;

namespace Recipes.NPoco.TryCrud;

[TestClass]
public class TryCrudTests : TryCrudTests<EmployeeClassification>
{
    protected override ITryCrudScenario<EmployeeClassification> GetScenario()
    {
        return new TryCrudScenario(Setup.SqlServerConnectionString);
    }
}