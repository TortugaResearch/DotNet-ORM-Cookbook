using Recipes.Dapper.Models;
using Recipes.Joins;

namespace Recipes.Dapper.Joins;

[TestClass]
public class JoinsTests : JoinsTests<EmployeeDetail, EmployeeSimple>
{
    protected override IJoinsScenario<EmployeeDetail, EmployeeSimple> GetScenario()
    {
        return new JoinsScenario(Setup.SqlServerConnectionString);
    }
}