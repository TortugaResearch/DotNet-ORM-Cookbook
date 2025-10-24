using Recipes.DbConnector.Models;
using Recipes.SoftDelete;

namespace Recipes.DbConnector.SoftDelete;

[TestClass]
public class SoftDeleteTests : SoftDeleteTests<Department>
{
    protected override ISoftDeleteScenario<Department> GetScenario()
    {
        return new SoftDeleteScenario(Setup.SqlServerConnectionString);
    }
}