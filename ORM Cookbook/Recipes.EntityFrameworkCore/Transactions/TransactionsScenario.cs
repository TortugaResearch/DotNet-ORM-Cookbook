using Microsoft.EntityFrameworkCore;
using Recipes.EntityFrameworkCore.Entities;
using Recipes.Transactions;
using System.Data;

namespace Recipes.EntityFrameworkCore.Transactions
{
    public class TransactionsScenario : ITransactionsScenario<EmployeeClassification>
    {
        private Func<OrmCookbookContext> CreateDbContext;

        public TransactionsScenario(Func<OrmCookbookContext> dBContextFactory)
        {
            CreateDbContext = dBContextFactory;
        }

        public int Create(EmployeeClassification classification, bool shouldRollBack)
        {
            using (var context = CreateDbContext())
            using (var trans = context.Database.BeginTransaction())
            {
                context.EmployeeClassifications.Add(classification);
                context.SaveChanges();
                var result = classification.EmployeeClassificationKey;

                if (shouldRollBack)
                    trans.Rollback();
                else
                    trans.Commit();

                return result;
            }
        }

        public int CreateWithIsolationLevel(EmployeeClassification classification, bool shouldRollBack, IsolationLevel isolationLevel)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var context = CreateDbContext())
            using (var trans = context.Database.BeginTransaction(isolationLevel))
            {
                context.EmployeeClassifications.Add(classification);
                context.SaveChanges();
                var result = classification.EmployeeClassificationKey;

                if (shouldRollBack)
                    trans.Rollback();
                else
                    trans.Commit();

                return result;
            }
        }

        public EmployeeClassification? GetByKey(int employeeClassificationKey)
        {
            using (var context = CreateDbContext())
                return context.EmployeeClassifications.Find(employeeClassificationKey);
        }
    }
}