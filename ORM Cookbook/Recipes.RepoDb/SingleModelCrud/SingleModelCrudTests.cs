using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.SingleModelCrud;

namespace Recipes.RepoDb.SingleModelCrud
{
    [TestClass]
    public class SingleModelCrudTests : SingleModelCrudTests<EmployeeClassification>
    {
        protected override ISingleModelCrudRepository<EmployeeClassification> GetRepository()
        {
            return new SingleModelCrudRepository(Setup.ConnectionString);
        }
    }
}
