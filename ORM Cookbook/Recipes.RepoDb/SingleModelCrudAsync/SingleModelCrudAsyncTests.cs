using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.SingleModelCrudAsync;

namespace Recipes.RepoDb.SingleModelCrudAsync
{
    [TestClass]
    public class SingleModelCrudAsyncTests : SingleModelCrudAsyncTests<EmployeeClassificationSingleModelCrudAsync>
    {
        protected override ISingleModelCrudAsyncRepository<EmployeeClassificationSingleModelCrudAsync> GetRepository()
        {
            return new SingleModelCrudAsyncRepository(Setup.ConnectionString);
        }
    }
}
