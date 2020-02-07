using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Recipes.ConnectionSharing;
using Recipes.EntityFrameworkCore.Entities;
using System;

namespace Recipes.EntityFrameworkCore.ConnectionSharing
{
    public class ConnectionSharingScenario : IConnectionSharingScenario<EmployeeClassification,
        SqlConnection, SqlTransaction>
    {
        readonly string m_ConnectionString;
        private Func<OrmCookbookContext> CreateDbContext;

        public ConnectionSharingScenario(Func<OrmCookbookContext> dBContextFactory, string connectionString)
        {
            m_ConnectionString = connectionString;
            CreateDbContext = dBContextFactory;
        }

        public void CloseConnection(object state)
        {
            if (state == null)
                throw new ArgumentNullException(nameof(state), $"{nameof(state)} is null.");

            var context = (OrmCookbookContext)state;
            context.Dispose();
        }

        public void CloseConnectionAndTransaction(object state)
        {
            if (state == null)
                throw new ArgumentNullException(nameof(state), $"{nameof(state)} is null.");

            var context = (OrmCookbookContext)state;
            context.Database.CommitTransaction();
            context.Dispose();
        }

        public string GetConnectionString()
        {
            return m_ConnectionString;
        }

        public (SqlConnection Connection, object State) OpenConnection()
        {
            var context = CreateDbContext();
            context.Database.OpenConnection(); //Force the connection open since we haven't used it yet.
            var connection = (SqlConnection)context.Database.GetDbConnection();
            return (connection, context);
        }

        public (SqlConnection Connection, SqlTransaction Transaction, object State) OpenConnectionAndTransaction()
        {
            var context = CreateDbContext();
            var connection = (SqlConnection)context.Database.GetDbConnection();
            var contextTransaction = context.Database.BeginTransaction();
            var transaction = (SqlTransaction)contextTransaction.GetDbTransaction();
            return (connection, transaction, context);
        }

        public EmployeeClassification UseOpenConnection(SqlConnection connection, SqlTransaction? transaction,
            int employeeClassificationKey)
        {
            var options = new DbContextOptionsBuilder<OrmCookbookContext>().UseSqlServer(connection).Options;
            using (var context = new OrmCookbookContext(options))
            {
                if (transaction != null)
                    context.Database.UseTransaction(transaction);

                return context.EmployeeClassification.Find(employeeClassificationKey);
            }
        }
    }
}
