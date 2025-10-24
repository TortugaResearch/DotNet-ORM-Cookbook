using Recipes.Chain.Models;
using Recipes.RowCount;

namespace Recipes.Chain.RowCount;

[TestClass]
public class RowCountTests : RowCountTests<EmployeeSimple>
{
    protected override IRowCountScenario<EmployeeSimple> GetScenario()
    {
        return new RowCountScenario(Setup.PrimaryDataSource);
    }
}