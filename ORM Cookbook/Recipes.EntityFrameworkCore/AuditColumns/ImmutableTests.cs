using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.AuditColumns;
using Recipes.EntityFrameworkCore.Entities;

namespace Recipes.EntityFrameworkCore.AuditColumns
{
    [TestClass]
    public class AuditColumnsTests : AuditColumnsTests<Department>
    {
        protected override IAuditColumnsScenario<Department> GetScenario()
        {
            return new AuditColumnsScenario(Setup.DBContextWithUserFactory);
        }
    }
}
