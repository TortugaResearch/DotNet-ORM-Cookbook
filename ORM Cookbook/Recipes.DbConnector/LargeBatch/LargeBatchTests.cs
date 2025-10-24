using Recipes.DbConnector.Models;
using Recipes.LargeBatch;

namespace Recipes.DbConnector.LargeBatch;

[TestClass]
public class LargeBatchTests : LargeBatchTests<EmployeeSimple>
{
    protected override ILargeBatchScenario<EmployeeSimple> GetScenario()
    {
        return new LargeBatchScenario(Setup.SqlServerConnectionString);
    }
}