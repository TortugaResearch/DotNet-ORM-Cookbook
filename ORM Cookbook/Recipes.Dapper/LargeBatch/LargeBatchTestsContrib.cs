using Recipes.Dapper.Models;
using Recipes.LargeBatch;

namespace Recipes.Dapper.LargeBatch;

[TestClass]
public class LargeBatchTestsContrib : LargeBatchTests<EmployeeSimple>
{
    protected override ILargeBatchScenario<EmployeeSimple> GetScenario()
    {
        return new LargeBatchScenarioContrib(Setup.SqlServerConnectionString);
    }
}