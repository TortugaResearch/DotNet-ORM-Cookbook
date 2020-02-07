using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.ConnectionSharing;
using Recipes.EntityFramework.Entities;
using System.Data.SqlClient;

namespace Recipes.EntityFramework.ConnectionSharing
{
    [TestClass]
    public class ConnectionSharingTests : ConnectionSharingTests<EmployeeClassification,
        SqlClientFactory, SqlConnection, SqlTransaction>
    {
        protected override SqlClientFactory CreateFactory()
        {
            return SqlClientFactory.Instance;
        }

        protected override IConnectionSharingScenario<EmployeeClassification, SqlConnection, SqlTransaction> GetScenario()
        {
            return new ConnectionSharingScenario(Setup.DBContextFactory, Setup.SqlServerConnectionString);
        }
    }
}