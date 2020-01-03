using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.NHibernate.Entities;
using Recipes.TryCrud;

namespace Recipes.NHibernate.TryCrud
{
    [TestClass]
    public class TryCrudTests : TryCrudTests<EmployeeClassification>
    {
        protected override ITryCrudRepository<EmployeeClassification> GetRepository()
        {
            return new TryCrudRepository(Setup.SessionFactory);
        }
    }
}
