using Recipes.DbConnector.Models;
using Recipes.RowCount;

namespace Recipes.DbConnector.RowCount;

[TestClass]
public class RowCountTests : RowCountTests<EmployeeSimple>
{
    protected override IRowCountScenario<EmployeeSimple> GetScenario()
    {
        return new RowCountScenario(Setup.SqlServerConnectionString);
    }
}