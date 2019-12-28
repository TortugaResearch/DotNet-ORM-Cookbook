using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.SingleModelCrud;
using Tortuga.Chain;

namespace Recipes.Chain.SingleModelCrud
{
    [TestClass]
    public class SingleModelCrudTests : SingleModelCrudTests<EmployeeClassification>
    {
        protected override ISingleModelCrudRepository<EmployeeClassification> GetRepository()
        {
            return new SingleModelCrudRepository(Setup.PrimaryDataSource);
        }
    }
}
