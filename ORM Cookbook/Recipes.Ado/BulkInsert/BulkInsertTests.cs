using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Ado.Models;
using Recipes.BulkInsert;

namespace Recipes.Ado.BulkInsert
{
    [TestClass]
    public class BulkInsertTests : BulkInsertTests<EmployeeSimple>
    {
        protected override IBulkInsertScenario<EmployeeSimple> GetScenario()
        {
            return new BulkInsertScenario(Setup.SqlServerConnectionString);
        }
    }
}
