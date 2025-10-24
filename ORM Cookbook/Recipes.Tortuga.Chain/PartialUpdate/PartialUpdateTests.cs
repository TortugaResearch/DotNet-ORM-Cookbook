using Recipes.Chain.Models;
using Recipes.PartialUpdate;

namespace Recipes.Chain.PartialUpdate;

[TestClass]
public class PartialUpdateTests : PartialUpdateTests<EmployeeClassification>
{
    protected override IPartialUpdateScenario<EmployeeClassification> GetScenario()
    {
        return new PartialUpdateScenario(Setup.PrimaryDataSource);
    }
}