using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Xpo.Entities;
using Recipes.Joins;

namespace Recipes.Xpo.Joins
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
