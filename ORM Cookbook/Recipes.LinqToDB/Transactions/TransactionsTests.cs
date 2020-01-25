using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.LinqToDB.Entities;
using Recipes.Transactions;

namespace Recipes.LinqToDB.Transactions
{
    [TestClass]
    public class TransactionsTests : TransactionsTests<EmployeeClassification>
    {
        protected override ITransactionsScenario<EmployeeClassification> GetScenario()
        {
            return new TransactionsScenario();
        }
    }
}
