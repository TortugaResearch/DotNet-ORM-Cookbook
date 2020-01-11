using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.RepoDb.Entities;
using Recipes.SingleModelCrud;

namespace Recipes.RepoDb.SingleModelCrud
{
    [TestClass]
    public class SingleModelCrudTests : SingleModelCrudTests<EmployeeClassificationSingleModelCrud>
    {
        protected override ISingleModelCrudRepository<EmployeeClassificationSingleModelCrud> GetRepository()
        {
            return new SingleModelCrudRepository(Setup.ConnectionString);
        }
    }
}
