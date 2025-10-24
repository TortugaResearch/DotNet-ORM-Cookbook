using Recipes.Joins;
using Recipes.RepoDB.Models;

namespace Recipes.RepoDB.Joins;

[TestClass]
public class JoinsTests : JoinsTests<EmployeeDetail, EmployeeSimple>
{
    protected override IJoinsScenario<EmployeeDetail, EmployeeSimple> GetScenario()
    {
        return new JoinsScenario(Setup.ConnectionString);
    }
}