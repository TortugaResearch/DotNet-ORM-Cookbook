using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Chain.Models;
using Recipes.ConnectionSharing;
using System.Data.SqlClient;

namespace Recipes.Chain.ConnectionSharing
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
            return new ConnectionSharingScenario(Setup.PrimaryDataSource, Setup.SqlServerConnectionString);
        }
    }
}