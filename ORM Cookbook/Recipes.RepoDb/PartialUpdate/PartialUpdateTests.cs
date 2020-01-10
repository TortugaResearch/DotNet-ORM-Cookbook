using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.PartialUpdate;

namespace Recipes.RepoDb.PartialUpdate
{
    [TestClass]
    public class PartialUpdateTests : PartialUpdateTests<EmployeeClassificationPartialUpdate>
    {
        protected override IPartialUpdateRepository<EmployeeClassificationPartialUpdate> GetRepository()
        {
            return new PartialUpdateRepository(Setup.ConnectionString);
        }
    }
}
