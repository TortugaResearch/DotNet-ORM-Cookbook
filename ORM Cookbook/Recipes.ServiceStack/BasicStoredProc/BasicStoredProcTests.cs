using Recipes.BasicStoredProc;
using Recipes.ServiceStack.Entities;

namespace Recipes.ServiceStack.BasicStoredProc;

[TestClass]
public class BasicStoredProcTests : BasicStoredProcTests<EmployeeClassification, EmployeeClassificationWithCount>
{
    protected override IBasicStoredProcScenario<EmployeeClassification, EmployeeClassificationWithCount> GetScenario()
    {
        return new BasicStoredProcScenario(Setup.DbConnectionFactory);
    }
}

[TestClass]
public class BasicStoredProcTests2 : BasicStoredProcTests<EmployeeClassification, EmployeeClassificationWithCount>
{
    protected override IBasicStoredProcScenario<EmployeeClassification, EmployeeClassificationWithCount> GetScenario()
    {
        return new BasicStoredProcScenario2(Setup.DbConnectionFactory);
    }
}