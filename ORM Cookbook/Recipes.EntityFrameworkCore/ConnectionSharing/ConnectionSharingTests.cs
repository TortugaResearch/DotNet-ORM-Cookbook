using Microsoft.Data.SqlClient;
using Recipes.ConnectionSharing;
using Recipes.EntityFrameworkCore.Entities;

namespace Recipes.EntityFrameworkCore.ConnectionSharing;

[TestClass]
public class ConnectionSharingTests : ConnectionSharingTests<EmployeeClassification,
    SqlClientFactory, SqlConnection, SqlTransaction, OrmCookbookContext>
{
    protected override SqlClientFactory CreateFactory()
    {
        return SqlClientFactory.Instance;
    }

    protected override IConnectionSharingScenario<EmployeeClassification, SqlConnection, SqlTransaction,
        OrmCookbookContext> GetScenario()
    {
        return new ConnectionSharingScenario(Setup.DBContextFactory, Setup.SqlServerConnectionString);
    }
}