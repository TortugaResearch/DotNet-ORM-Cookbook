using Recipes.PetaPoco.Models;
using Recipes.RowCount;

namespace Recipes.PetaPoco.RowCount;

[TestClass]
public class RowCountTests : RowCountTests<EmployeeSimple>
{
    protected override IRowCountScenario<EmployeeSimple> GetScenario()
    {
        return new RowCountScenario(Setup.SqlServerConnectionString);
    }
}