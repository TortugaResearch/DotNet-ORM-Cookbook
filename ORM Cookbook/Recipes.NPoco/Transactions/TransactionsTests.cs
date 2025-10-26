using Recipes.NPoco.Models;
using Recipes.Transactions;

namespace Recipes.NPoco.Transactions;

[TestClass]
public class TransactionsTests : TransactionsTests<EmployeeClassification>
{
    protected override ITransactionsScenario<EmployeeClassification> GetScenario()
    {
        return new TransactionsScenario(Setup.SqlServerConnectionString);
    }
}