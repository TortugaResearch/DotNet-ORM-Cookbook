using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Ado.Models;
using Recipes.AuditColumns;

namespace Recipes.Ado.AuditColumns
{
    [TestClass]
    public class AuditColumnsTests : AuditColumnsTests<Department>
    {
        protected override IAuditColumnsScenario<Department> GetScenario()
        {
            return new AuditColumnsScenario(Setup.SqlServerConnectionString);
        }
    }
}
