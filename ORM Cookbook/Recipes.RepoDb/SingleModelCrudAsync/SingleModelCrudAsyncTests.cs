using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.SingleModelCrudAsync;

namespace Recipes.RepoDb.SingleModelCrudAsync
{
    [TestClass]
    public class SingleModelCrudAsyncTests : SingleModelCrudAsyncTests<EmployeeClassification>
    {
        protected override ISingleModelCrudAsyncRepository<EmployeeClassification> GetRepository()
        {
            return new SingleModelCrudAsyncRepository(Setup.ConnectionString);
        }
    }
}
