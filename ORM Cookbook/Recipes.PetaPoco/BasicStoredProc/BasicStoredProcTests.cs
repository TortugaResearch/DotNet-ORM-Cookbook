using Recipes.BasicStoredProc;
using Recipes.PetaPoco.Models;

namespace Recipes.PetaPoco.BasicStoredProc;

[TestClass]
public class BasicStoredProcTests : BasicStoredProcTests<EmployeeClassification, EmployeeClassificationWithCount>
{
    protected override IBasicStoredProcScenario<EmployeeClassification, EmployeeClassificationWithCount> GetScenario()
    {
        return new BasicStoredProcScenario(Setup.SqlServerConnectionString);
    }
}