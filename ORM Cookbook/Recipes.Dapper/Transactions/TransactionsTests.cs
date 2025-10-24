using Recipes.Dapper.Models;
using Recipes.Transactions;

namespace Recipes.Dapper.Transactions;

[TestClass]
public class TransactionsTests : TransactionsTests<EmployeeClassification>
{
    protected override ITransactionsScenario<EmployeeClassification> GetScenario()
    {
        return new TransactionsScenario(Setup.SqlServerConnectionString);
    }
}