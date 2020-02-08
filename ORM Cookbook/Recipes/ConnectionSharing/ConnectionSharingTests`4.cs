using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Data.Common;

namespace Recipes.ConnectionSharing
{
    /// <summary>
    /// This scenario performs basic CRUD operations on a simple model without children.
    /// </summary>
    /// <typeparam name="TModel">A EmployeeClassification model or entity</typeparam>
    [TestCategory("ConnectionSharing")]
    public abstract class ConnectionSharingTests<TModel, TFactory, TConnection, TTransaction, TState> : TestBase
        where TModel : class, IEmployeeClassification, new()
        where TFactory : DbProviderFactory
        where TConnection : DbConnection
        where TTransaction : DbTransaction
    {
        protected abstract TFactory CreateFactory();

        [TestMethod]
        public void UseSharedConnection()
        {
            var repository = GetScenario();
            var factory = CreateFactory();
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = repository.GetConnectionString();
                connection.Open();

                var result = repository.UseOpenConnection((TConnection)connection, null, 1);
                Assert.AreEqual("Full Time Salary", result.EmployeeClassificationName);
                Assert.AreEqual(ConnectionState.Open, connection.State, "Connection should have been left open");
            }
        }

        [TestMethod]
        public void UseSharedConnectionAndTransaction()
        {
            var repository = GetScenario();
            var factory = CreateFactory();
            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = repository.GetConnectionString();
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    var result = repository.UseOpenConnection((TConnection)connection, (TTransaction)transaction, 1);
                    Assert.AreEqual("Full Time Salary", result.EmployeeClassificationName);
                    Assert.AreEqual(ConnectionState.Open, connection.State, "Connection should have been left open");

                    transaction.Commit();
                }
            }
        }

        [TestMethod]
        public void ShareConnection()
        {
            var repository = GetScenario();
            var factory = CreateFactory();

            (var connection, var state) = repository.OpenConnection();
            Assert.IsNotNull(connection);
            Assert.AreEqual(ConnectionState.Open, connection.State);

            using (var cmd = factory.CreateCommand())
            {
                cmd.Connection = connection;
                cmd.CommandText = "SELECT 1";
                var result = (int)cmd.ExecuteScalar();
                Assert.AreEqual(1, result);
            }

            repository.CloseConnection(state);

            Assert.AreEqual(ConnectionState.Closed, connection.State);
        }

        [TestMethod]
        public void ShareConnectionAndTransaction()
        {
            var repository = GetScenario();
            var factory = CreateFactory();

            (var connection, var transaction, var state) = repository.OpenConnectionAndTransaction();
            Assert.IsNotNull(connection);
            Assert.AreEqual(ConnectionState.Open, connection.State);
            Assert.IsNotNull(transaction);

            using (var cmd = factory.CreateCommand())
            {
                cmd.Connection = connection;
                cmd.Transaction = transaction;
                cmd.CommandText = "SELECT 1";
                var result = (int)cmd.ExecuteScalar();
                Assert.AreEqual(1, result);
            }

            repository.CloseConnectionAndTransaction(state);

            Assert.AreEqual(ConnectionState.Closed, connection.State);
        }

        protected abstract IConnectionSharingScenario<TModel, TConnection, TTransaction, TState> GetScenario();
    }
}
