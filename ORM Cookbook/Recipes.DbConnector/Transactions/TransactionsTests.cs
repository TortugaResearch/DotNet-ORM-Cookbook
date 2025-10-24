using Recipes.DbConnector.Models;
using Recipes.Transactions;

namespace Recipes.DbConnector.Transactions;

[TestClass]
public class TransactionsTests : TransactionsTests<EmployeeClassification>
{
    protected override ITransactionsScenario<EmployeeClassification> GetScenario()
    {
        return new TransactionsScenario(Setup.SqlServerConnectionString);
    }
}