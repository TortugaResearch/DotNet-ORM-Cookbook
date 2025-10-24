using Recipes.PartialUpdate;
using Recipes.ServiceStack.Entities;

namespace Recipes.ServiceStack.PartialUpdate;

[TestClass]
public class PartialUpdateTests : PartialUpdateTests<EmployeeClassificationPartial>
{
    protected override IPartialUpdateScenario<EmployeeClassificationPartial> GetScenario()
    {
        return new PartialUpdateScenario(Setup.DbConnectionFactory);
    }
}