using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.AuditColumns;
using Recipes.Xpo.Entities;

namespace Recipes.Xpo.AuditColumns
{
    [TestClass]
    public class AuditColumnsTests : AuditColumnsTests<Department>
    {
        protected override IAuditColumnsScenario<Department> GetScenario()
        {
            return new AuditColumnsScenario();
        }
    }
}
