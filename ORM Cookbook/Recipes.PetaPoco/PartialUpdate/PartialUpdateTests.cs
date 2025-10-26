using Recipes.PetaPoco.Models;
using Recipes.PartialUpdate;

namespace Recipes.PetaPoco.PartialUpdate;

[TestClass]
public class PartialUpdateTests : PartialUpdateTests<EmployeeClassification>
{
    protected override IPartialUpdateScenario<EmployeeClassification> GetScenario()
    {
        return new PartialUpdateScenario(Setup.SqlServerConnectionString);
    }
}