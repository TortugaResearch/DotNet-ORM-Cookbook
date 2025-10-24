using Recipes.PartialUpdate;
using Recipes.RepoDB.Models;

namespace Recipes.RepoDB.PartialUpdate;

[TestClass]
public class PartialUpdateTests : PartialUpdateTests<EmployeeClassification>
{
    protected override IPartialUpdateScenario<EmployeeClassification> GetScenario()
    {
        return new PartialUpdateScenario(Setup.ConnectionString);
    }
}