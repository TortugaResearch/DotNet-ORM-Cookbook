using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.LinqToDB.Entities;
using Recipes.Joins;

namespace Recipes.LinqToDB.Joins
{
    [TestClass]
    public class JoinsTests : JoinsTests<EmployeeDetail, Employee>
    {
        protected override IJoinsScenario<EmployeeDetail, Employee> GetScenario()
        {
            return new JoinsScenario();
        }
    }
}
