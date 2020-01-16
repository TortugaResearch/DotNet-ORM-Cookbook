using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.PartialUpdate;
using Recipes.RepoDb.Entities;

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
