using Recipes.BulkInsert;
using Recipes.DbConnector.Models;

namespace Recipes.DbConnector.BulkInsert;

[TestClass]
public class BulkInsertTests : BulkInsertTests<EmployeeSimple>
{
    protected override IBulkInsertScenario<EmployeeSimple> GetScenario()
    {
        return new BulkInsertScenario(Setup.SqlServerConnectionString);
    }
}