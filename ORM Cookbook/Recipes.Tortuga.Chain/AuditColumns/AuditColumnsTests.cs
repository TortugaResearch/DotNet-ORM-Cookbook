using Recipes.AuditColumns;
using Recipes.Chain.Models;

namespace Recipes.Chain.AuditColumns;

[TestClass]
public class AuditColumnsTests : AuditColumnsTests<Department>
{
    protected override IAuditColumnsScenario<Department> GetScenario()
    {
        return new AuditColumnsScenario(Setup.PrimaryDataSource);
    }
}