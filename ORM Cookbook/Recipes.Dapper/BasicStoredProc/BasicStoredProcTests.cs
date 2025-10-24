using Recipes.BasicStoredProc;
using Recipes.Dapper.Models;

namespace Recipes.Dapper.BasicStoredProc;

[TestClass]
public class BasicStoredProcTests : BasicStoredProcTests<EmployeeClassification, EmployeeClassificationWithCount>
{
    protected override IBasicStoredProcScenario<EmployeeClassification, EmployeeClassificationWithCount> GetScenario()
    {
        return new BasicStoredProcScenario(Setup.SqlServerConnectionString);
    }
}