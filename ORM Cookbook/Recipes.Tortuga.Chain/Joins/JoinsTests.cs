using Recipes.Chain.Models;
using Recipes.Joins;

namespace Recipes.Chain.Joins;

[TestClass]
public class JoinsTests : JoinsTests<EmployeeDetail, EmployeeSimple>
{
    protected override IJoinsScenario<EmployeeDetail, EmployeeSimple> GetScenario()
    {
        return new JoinsScenario(Setup.PrimaryDataSource);
    }
}