using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.RepoDb.Models;
using Recipes.Joins;

namespace Recipes.RepoDb.Joins
{
    [TestClass]
    public class JoinsTests : JoinsTests<EmployeeDetail, EmployeeSimple>
    {
        protected override IJoinsScenario<EmployeeDetail, EmployeeSimple> GetScenario()
        {
            return new JoinsScenario(Setup.ConnectionString);
        }
    }
}
