using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.TryCrud;

namespace Recipes.Ado.TryCrud
{
    [TestClass]
    public class TryCrudTests : TryCrudTests<EmployeeClassification>
    {
        protected override ITryCrudRepository<EmployeeClassification> GetRepository()
        {
            return new TryCrudRepository(Setup.ConnectionString);
        }
    }
}
