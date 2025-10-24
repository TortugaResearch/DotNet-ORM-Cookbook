using Recipes.EntityFrameworkCore.Entities;
using Recipes.RowCount;

namespace Recipes.EntityFrameworkCore.RowCount;

[TestClass]
public class RowCountTests : RowCountTests<Employee>
{
    protected override IRowCountScenario<Employee> GetScenario()
    {
        return new RowCountScenario(Setup.DBContextFactory);
    }
}