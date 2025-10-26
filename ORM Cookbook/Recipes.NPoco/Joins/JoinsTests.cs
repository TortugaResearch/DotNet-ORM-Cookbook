using Recipes.NPoco.Models;
using Recipes.Joins;

namespace Recipes.NPoco.Joins;

[TestClass]
public class JoinsTests : JoinsTests<EmployeeDetail, EmployeeSimple>
{
    protected override IJoinsScenario<EmployeeDetail, EmployeeSimple> GetScenario()
    {
        return new JoinsScenario(Setup.SqlServerConnectionString);
    }
}