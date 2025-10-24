using Recipes.EntityFramework.Entities;
using Recipes.Joins;

namespace Recipes.EntityFramework.Joins;

[TestClass]
public class JoinsTests : JoinsTests<EmployeeDetail, Employee>
{
    protected override IJoinsScenario<EmployeeDetail, Employee> GetScenario()
    {
        return new JoinsScenario(Setup.DBContextFactory);
    }
}