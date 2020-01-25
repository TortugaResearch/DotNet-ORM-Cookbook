using LLBLGenPro.OrmCookbook.EntityClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Transactions;

namespace Recipes.LLBLGenPro.Transactions
{
    [TestClass]
    public class TransactionsTests : TransactionsTests<EmployeeClassificationEntity>
    {
        protected override ITransactionsScenario<EmployeeClassificationEntity> GetScenario()
        {
            return new TransactionsScenario();
        }
    }
}
