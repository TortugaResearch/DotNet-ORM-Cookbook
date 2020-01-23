using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.RepoDb;
using Recipes.RepoDb.Models;
using Recipes.RepoDb.RowCount;
using Recipes.RowCount;

namespace Recipes.RepoDb.RowCount
{
    [TestClass]
    public class RowCountTests : RowCountTests<EmployeeSimple>
    {
        protected override IRowCountScenario<EmployeeSimple> GetScenario()
        {
            return new RowCountScenario(Setup.ConnectionString);
        }
    }
}
