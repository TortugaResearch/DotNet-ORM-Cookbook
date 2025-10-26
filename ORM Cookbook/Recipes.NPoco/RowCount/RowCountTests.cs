using Recipes.NPoco.Models;
using Recipes.RowCount;

namespace Recipes.NPoco.RowCount;

[TestClass]
public class RowCountTests : RowCountTests<EmployeeSimple>
{
    protected override IRowCountScenario<EmployeeSimple> GetScenario()
    {
        return new RowCountScenario(Setup.SqlServerConnectionString);
    }
}