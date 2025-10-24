using Recipes.RowCount;
using Recipes.ServiceStack.Entities;

namespace Recipes.ServiceStack.RowCount;

[TestClass]
public class RowCountTests : RowCountTests<Employee>
{
    protected override IRowCountScenario<Employee> GetScenario()
    {
        return new RowCountScenario(Setup.DbConnectionFactory);
    }
}