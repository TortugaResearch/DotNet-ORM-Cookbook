using Recipes.Dapper.Models;
using Recipes.PartialUpdate;

namespace Recipes.Dapper.PartialUpdate;

[TestClass]
public class PartialUpdateTests : PartialUpdateTests<EmployeeClassification>
{
    protected override IPartialUpdateScenario<EmployeeClassification> GetScenario()
    {
        return new PartialUpdateScenario(Setup.SqlServerConnectionString);
    }
}