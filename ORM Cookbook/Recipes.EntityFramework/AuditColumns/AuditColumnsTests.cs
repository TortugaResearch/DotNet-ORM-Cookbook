using Recipes.AuditColumns;
using Recipes.EntityFramework.Entities;

namespace Recipes.EntityFramework.AuditColumns;

[TestClass]
public class AuditColumnsTests : AuditColumnsTests<Department>
{
    protected override IAuditColumnsScenario<Department> GetScenario()
    {
        return new AuditColumnsScenario(Setup.DBContextWithUserFactory);
    }
}