using Recipes.Chain.Models;
using Recipes.ConnectionSharing;
using System;
using System.Data.SqlClient;
using Tortuga.Chain;
using Tortuga.Chain.DataSources;

namespace Recipes.Chain.ConnectionSharing
{
    public class ConnectionSharingScenario : IConnectionSharingScenario<EmployeeClassification,
        SqlConnection, SqlTransaction>
    {
        readonly SqlServerDataSource m_DataSource;
        readonly string m_ConnectionString;
        const string TableName = "HR.EmployeeClassification";

        public ConnectionSharingScenario(SqlServerDataSource dataSource, string connectionString)
        {
            m_ConnectionString = connectionString;
            m_DataSource = dataSource;
        }

        public void CloseConnection(object state)
        {
            if (state == null)
                throw new ArgumentNullException(nameof(state), $"{nameof(state)} is null.");

            var dataSource = (IOpenDataSource)state;
            dataSource.Close();
        }

        public void CloseConnectionAndTransaction(object state)
        {
            if (state == null)
                throw new ArgumentNullException(nameof(state), $"{nameof(state)} is null.");

            var dataSource = (IOpenDataSource)state;
            dataSource.TryCommit();
            dataSource.Close();
        }

        public string GetConnectionString()
        {
            return m_ConnectionString;
        }

        public (SqlConnection Connection, object State) OpenConnection()
        {
            var connection = m_DataSource.CreateConnection();
            var openDataSource = m_DataSource.CreateOpenDataSource(connection);
            return (connection, openDataSource);
        }

        public (SqlConnection Connection, SqlTransaction Transaction, object State) OpenConnectionAndTransaction()
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
            return openDataSource.GetByKey(TableName, employeeClassificationKey)
                .ToObject<EmployeeClassification>().Execute();
        }
    }
}