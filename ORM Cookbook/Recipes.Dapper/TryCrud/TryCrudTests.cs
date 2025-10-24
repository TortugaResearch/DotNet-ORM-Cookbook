using Recipes.Dapper.Models;
using Recipes.TryCrud;

namespace Recipes.Dapper.TryCrud;

[TestClass]
public class TryCrudTests : TryCrudTests<EmployeeClassification>
{
    protected override ITryCrudScenario<EmployeeClassification> GetScenario()
    {
        return new TryCrudScenario(Setup.SqlServerConnectionString);
    }
}