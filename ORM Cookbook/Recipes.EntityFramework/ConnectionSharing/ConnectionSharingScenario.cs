using Recipes.ConnectionSharing;
using Recipes.EntityFramework.Entities;
using System;
using System.Data.SqlClient;

namespace Recipes.EntityFramework.ConnectionSharing
{
    public class ConnectionSharingScenario : IConnectionSharingScenario<EmployeeClassification,
        SqlConnection, SqlTransaction, OrmCookbookContext>
    {
        readonly string m_ConnectionString;
        private Func<OrmCookbookContext> CreateDbContext;

        public ConnectionSharingScenario(Func<OrmCookbookContext> dBContextFactory, string connectionString)
        {
            m_ConnectionString = connectionString;
            CreateDbContext = dBContextFactory;
        }

        public void CloseConnection(OrmCookbookContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context), $"{nameof(context)} is null.");

            context.Dispose();
        }

        public void CloseConnectionAndTransaction(OrmCookbookContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context), $"{nameof(context)} is null.");

            var contextTransaction = context.Database.CurrentTransaction;
            contextTransaction.Commit();
            context.Dispose();
        }

        public string GetConnectionString()
        {
            return m_ConnectionString;
        }

        public ConnectionResult<SqlConnection, OrmCookbookContext> OpenConnection()
        {
            var context = CreateDbContext();
            context.Database.Connection.Open(); //Force the connection open since we haven't used it yet.
            var connection = (SqlConnection)context.Database.Connection;
            return (connection, context);
        }

        public ConnectionTransactionResult<SqlConnection, SqlTransaction, OrmCookbookContext>
            OpenConnectionAndTransaction()
        {
            var context = CreateDbContext();
            var connection = (SqlConnection)context.Database.Connection;
            var contextTransaction = context.Database.BeginTransaction();
            var transaction = (SqlTransaction)contextTransaction.UnderlyingTransaction;
            return (connection, transaction, context);
        }

        public EmployeeClassification UseOpenConnection(SqlConnection connection, SqlTransaction? transaction,
            int employeeClassificationKey)
        {
            //Set contextOwnsConnection to false so the underlying connection will not be closed
            using (var context = new OrmCookbookContext(connection, contextOwnsConnection: false))
            {
                if (transaction != null)
                    context.Database.UseTransaction(transaction);

                return context.EmployeeClassification.Find(employeeClassificationKey);
            }
        }
    }
}
