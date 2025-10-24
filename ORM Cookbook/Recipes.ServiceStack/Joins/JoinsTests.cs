using Recipes.Joins;
using Recipes.ServiceStack.Entities;

namespace Recipes.ServiceStack.Joins;

[TestClass]
public class JoinsTests : JoinsTests<EmployeeDetail, Employee>
{
    protected override IJoinsScenario<EmployeeDetail, Employee> GetScenario()
    {
        return new JoinsScenario(Setup.DbConnectionFactory);
    }
}