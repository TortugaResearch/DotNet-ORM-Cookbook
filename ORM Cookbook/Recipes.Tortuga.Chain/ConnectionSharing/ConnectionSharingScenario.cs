using Recipes.Chain.Models;
using Recipes.ConnectionSharing;
using System;
using System.Data.SqlClient;
using Tortuga.Chain;
using Tortuga.Chain.DataSources;

namespace Recipes.Chain.ConnectionSharing
{
    public class ConnectionSharingScenario : IConnectionSharingScenario<EmployeeClassification,
        SqlConnection, SqlTransaction, IOpenDataSource>
    {
        readonly SqlServerDataSource m_DataSource;
        readonly string m_ConnectionString;

        public ConnectionSharingScenario(SqlServerDataSource dataSource, string connectionString)
        {
            m_ConnectionString = connectionString;
            m_DataSource = dataSource;
        }

        public void CloseConnection(IOpenDataSource dataSource)
        {
            if (dataSource == null)
                throw new ArgumentNullException(nameof(dataSource), $"{nameof(dataSource)} is null.");

            dataSource.Close();
        }

        public void CloseConnectionAndTransaction(IOpenDataSource dataSource)
        {
            if (dataSource == null)
                throw new ArgumentNullException(nameof(dataSource), $"{nameof(dataSource)} is null.");

            dataSource.TryCommit();
            dataSource.Close();
        }

        public string GetConnectionString()
        {
            return m_ConnectionString;
        }

        public ConnectionResult<SqlConnection, IOpenDataSource> OpenConnection()
        {
            var connection = m_DataSource.CreateConnection();
            var openDataSource = m_DataSource.CreateOpenDataSource(connection);
            return (connection, openDataSource);
        }

        public ConnectionTransactionResult<SqlConnection, SqlTransaction, IOpenDataSource>
            OpenConnectionAndTransaction()
        {
            var connection = m_DataSource.CreateConnection();
            var transaction = connection.BeginTransaction();
            var openDataSource = m_DataSource.CreateOpenDataSource(connection, transaction);
            return (connection, transaction, openDataSource);
        }

        public EmployeeClassification UseOpenConnection(SqlConnection connection, SqlTransaction? transaction,
            int employeeClassificationKey)
        {
            var openDataSource = m_DataSource.CreateOpenDataSource(connection, transaction);
            return openDataSource.GetByKey<EmployeeClassification>(employeeClassificationKey)
                .ToObject<EmployeeClassification>().Execute();
        }
    }
}
