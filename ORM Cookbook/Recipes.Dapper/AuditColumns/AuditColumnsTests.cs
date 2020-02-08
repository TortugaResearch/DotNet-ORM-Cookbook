using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.AuditColumns;
using Recipes.Dapper.Models;

namespace Recipes.Dapper.AuditColumns
{
    [TestClass]
    public class AuditColumnsTests : AuditColumnsTests<Department>
    {
        protected override IAuditColumnsScenario<Department> GetScenario()
        {
            return new AuditColumnsScenario(Setup.ConnectionString);
        }
    }
}
