using Recipes.EntityFrameworkCore.Entities;
using Recipes.Transactions;

namespace Recipes.EntityFrameworkCore.Transactions
{
    [TestClass]
    public class TransactionsTests : TransactionsTests<EmployeeClassification>
    {
        protected override ITransactionsScenario<EmployeeClassification> GetScenario()
        {
            return new TransactionsScenario(Setup.DBContextFactory);
        }
    }
}