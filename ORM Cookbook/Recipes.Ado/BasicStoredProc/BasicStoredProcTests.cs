using Recipes.Ado.Models;
using Recipes.BasicStoredProc;

namespace Recipes.Ado.BasicStoredProc;

[TestClass]
public class BasicStoredProcTests : BasicStoredProcTests<EmployeeClassification, EmployeeClassificationWithCount>
{
    protected override IBasicStoredProcScenario<EmployeeClassification, EmployeeClassificationWithCount> GetScenario()
    {
        return new BasicStoredProcScenario(Setup.SqlServerConnectionString);
    }
}