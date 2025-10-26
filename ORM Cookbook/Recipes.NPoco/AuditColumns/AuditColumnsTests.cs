using Recipes.AuditColumns;
using Recipes.NPoco.Models;

namespace Recipes.NPoco.AuditColumns;

[TestClass]
public class AuditColumnsTests : AuditColumnsTests<Department>
{
    protected override IAuditColumnsScenario<Department> GetScenario()
    {
        return new AuditColumnsScenario(Setup.SqlServerConnectionString);
    }
}