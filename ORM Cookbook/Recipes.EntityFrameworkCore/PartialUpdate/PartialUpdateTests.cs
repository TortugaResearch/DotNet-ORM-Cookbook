using Recipes.EntityFrameworkCore.Entities;
using Recipes.PartialUpdate;

namespace Recipes.EntityFrameworkCore.PartialUpdate;

[TestClass]
public class PartialUpdateTests : PartialUpdateTests<EmployeeClassification>
{
    protected override IPartialUpdateScenario<EmployeeClassification> GetScenario()
    {
        return new PartialUpdateScenario(Setup.DBContextFactory);
    }
}