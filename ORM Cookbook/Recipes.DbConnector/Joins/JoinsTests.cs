using Recipes.DbConnector.Models;
using Recipes.Joins;

namespace Recipes.DbConnector.Joins;

[TestClass]
public class JoinsTests : JoinsTests<EmployeeDetail, EmployeeSimple>
{
    protected override IJoinsScenario<EmployeeDetail, EmployeeSimple> GetScenario()
    {
        return new JoinsScenario(Setup.SqlServerConnectionString);
    }
}