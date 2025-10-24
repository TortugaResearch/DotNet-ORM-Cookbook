using Recipes.EntityFrameworkCore.Entities;
using Recipes.Joins;

namespace Recipes.EntityFrameworkCore.Joins;

[TestClass]
public class JoinsTests : JoinsTests<EmployeeDetail, Employee>
{
    protected override IJoinsScenario<EmployeeDetail, Employee> GetScenario()
    {
        return new JoinsScenario(Setup.DBContextFactory);
    }
}