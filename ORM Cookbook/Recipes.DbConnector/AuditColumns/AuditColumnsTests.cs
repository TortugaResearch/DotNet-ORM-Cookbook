using Recipes.AuditColumns;
using Recipes.DbConnector.Models;

namespace Recipes.DbConnector.AuditColumns;

[TestClass]
public class AuditColumnsTests : AuditColumnsTests<Department>
{
    protected override IAuditColumnsScenario<Department> GetScenario()
    {
        return new AuditColumnsScenario(Setup.SqlServerConnectionString);
    }
}