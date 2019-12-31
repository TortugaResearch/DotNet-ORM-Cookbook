using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.SingleModelCrudAsync;

namespace Recipes.Chain.SingleModelCrudAsync
{
    [TestClass]
    public class SingleModelCrudAsyncCompiledTests : SingleModelCrudAsyncTests<EmployeeClassification>
    {
        protected override ISingleModelCrudAsyncRepository<EmployeeClassification> GetRepository()
        {
            return new SingleModelCrudAsyncCompiledRepository(Setup.PrimaryDataSource);
        }
    }
}
