using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.TryCrud;

namespace Recipes.Dapper.TryCrud
{
    [TestClass]
    public class TryCrudTests : TryCrudTests<EmployeeClassification>
    {
        protected override ITryCrudRepository<EmployeeClassification> GetRepository()
        {
            throw new AssertInconclusiveException("TODO");
        }
    }
}
