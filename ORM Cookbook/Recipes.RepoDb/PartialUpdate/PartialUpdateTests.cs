using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.PartialUpdate;
using Recipes.RepoDb.Models;

namespace Recipes.RepoDb.PartialUpdate
{
    [TestClass]
    public class PartialUpdateTests : PartialUpdateTests<EmployeeClassification>
    {
        protected override IPartialUpdateScenario<EmployeeClassification> GetScenario()
        {
            return new PartialUpdateScenario(Setup.ConnectionString);
        }
    }
}
