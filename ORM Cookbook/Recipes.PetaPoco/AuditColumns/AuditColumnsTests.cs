using Recipes.AuditColumns;
using Recipes.PetaPoco.Models;

namespace Recipes.PetaPoco.AuditColumns;

[TestClass]
public class AuditColumnsTests : AuditColumnsTests<Department>
{
    protected override IAuditColumnsScenario<Department> GetScenario()
    {
        return new AuditColumnsScenario(Setup.SqlServerConnectionString);
    }
}