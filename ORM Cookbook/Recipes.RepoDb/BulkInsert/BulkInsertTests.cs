using Recipes.BulkInsert;
using Recipes.RepoDB.Models;

namespace Recipes.RepoDB.BulkInsert;

[TestClass]
public class BulkInsertTests : BulkInsertTests<EmployeeSimple>
{
    protected override IBulkInsertScenario<EmployeeSimple> GetScenario()
    {
        return new BulkInsertScenario(Setup.ConnectionString);
    }
}