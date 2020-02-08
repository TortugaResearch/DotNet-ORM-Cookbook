using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.RepoDb.Models;
using Recipes.BulkInsert;

namespace Recipes.RepoDb.BulkInsert
{
    [TestClass]
    public class BulkInsertTests : BulkInsertTests<EmployeeSimple>
    {
        protected override IBulkInsertScenario<EmployeeSimple> GetScenario()
        {
            return new BulkInsertScenario(Setup.ConnectionString);
        }
    }
}
