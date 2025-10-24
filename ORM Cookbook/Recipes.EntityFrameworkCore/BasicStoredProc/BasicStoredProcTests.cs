using Recipes.BasicStoredProc;
using Recipes.EntityFrameworkCore.Entities;

namespace Recipes.EntityFrameworkCore.BasicStoredProc;

[TestClass]
public class BasicStoredProcTests : BasicStoredProcTests<EmployeeClassification, EmployeeClassificationWithCount>
{
    protected override IBasicStoredProcScenario<EmployeeClassification, EmployeeClassificationWithCount> GetScenario()
    {
        return new BasicStoredProcScenario(Setup.DBContextFactory);
    }
}