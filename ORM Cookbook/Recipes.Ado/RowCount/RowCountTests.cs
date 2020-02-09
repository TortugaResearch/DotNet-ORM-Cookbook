using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Ado.Models;
using Recipes.RowCount;

namespace Recipes.Ado.RowCount
{
    [TestClass]
    public class RowCountTests : RowCountTests<EmployeeSimple>
    {
        protected override IRowCountScenario<EmployeeSimple> GetScenario()
        {
            return new RowCountScenario(Setup.SqlServerConnectionString);
        }
    }
}
