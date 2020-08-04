using Recipes.Xpo.Entities;
using Recipes.Transactions;
using System;
using System.Data;
using DevExpress.Xpo;

namespace Recipes.Xpo.Transactions
{
    public class TransactionsScenario : ITransactionsScenario<EmployeeClassification>
    {

        public int Create(EmployeeClassification classification, bool shouldRollBack)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var uow = new UnitOfWork())
            {
                EmployeeClassification ec = new EmployeeClassification(uow);
                ec.EmployeeClassificationName = classification.EmployeeClassificationName;

                uow.ExplicitBeginTransaction();

                uow.CommitChanges();

                if (shouldRollBack)
                    uow.ExplicitRollbackTransaction();
                else
                    uow.ExplicitCommitTransaction();
                var result = ec.EmployeeClassificationKey;

                return result;

            }
        }

        public int CreateWithIsolationLevel(EmployeeClassification classification, bool shouldRollBack, IsolationLevel isolationLevel)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");
            using (var uow = new UnitOfWork())
            {
                EmployeeClassification ec = new EmployeeClassification(uow);
                ec.EmployeeClassificationName = classification.EmployeeClassificationName;

                uow.ExplicitBeginTransaction(isolationLevel);

                uow.CommitChanges();

                if (shouldRollBack)
                    uow.ExplicitRollbackTransaction();
                else
                    uow.ExplicitCommitTransaction();
                var result = ec.EmployeeClassificationKey;

                return result;
            }
        }

        public EmployeeClassification GetByKey(int employeeClassificationKey)
        {
            return Session.DefaultSession.GetObjectByKey<EmployeeClassification>(employeeClassificationKey);
        }
    }
}
