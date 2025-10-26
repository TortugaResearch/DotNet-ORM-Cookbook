using Recipes.NPoco.Models;
using Recipes.PartialUpdate;

namespace Recipes.NPoco.PartialUpdate;

[TestClass]
public class PartialUpdateTests : PartialUpdateTests<EmployeeClassification>
{
    protected override IPartialUpdateScenario<EmployeeClassification> GetScenario()
    {
        return new PartialUpdateScenario(Setup.SqlServerConnectionString);
    }
}