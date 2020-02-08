using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Chain.Models;
using Recipes.ConnectionSharing;
using System.Data.SqlClient;
using Tortuga.Chain.DataSources;

namespace Recipes.Chain.ConnectionSharing
{
    [TestClass]
    public class ConnectionSharingTests : ConnectionSharingTests<EmployeeClassification,
        SqlClientFactory, SqlConnection, SqlTransaction, IOpenDataSource>
    {
        protected override SqlClientFactory CreateFactory()
        {
            return SqlClientFactory.Instance;
        }

        protected override IConnectionSharingScenario<EmployeeClassification, SqlConnection, SqlTransaction,
            IOpenDataSource> GetScenario()
        {
            return new ConnectionSharingScenario(Setup.PrimaryDataSource, Setup.SqlServerConnectionString);
        }
    }
}
