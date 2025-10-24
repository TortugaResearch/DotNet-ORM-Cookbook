using Recipes.RepoDB.Models;
using Recipes.RowCount;

namespace Recipes.RepoDB.RowCount
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