using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Dapper.Models;
using Recipes.MultipleCrud;

namespace Recipes.Dapper.MultipleCrud
{
    [TestClass]
    public class MultipleCrudTestsContrib : MultipleCrudTests<EmployeeSimple>
    {
        protected override IMultipleCrudScenario<EmployeeSimple> GetScenario()
        {
            return new MultipleCrudScenarioContrib(Setup.ConnectionString);
        }
    }
}
