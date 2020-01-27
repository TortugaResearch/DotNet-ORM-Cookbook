using LLBLGenPro.OrmCookbook.DatabaseSpecific;
using LLBLGenPro.OrmCookbook.EntityClasses;
using LLBLGenPro.OrmCookbook.Linq;
using Recipes.Transactions;
using System;
using System.Data;
using System.Linq;

namespace Recipes.LLBLGenPro.Transactions
{
    public class TransactionsScenario : ITransactionsScenario<EmployeeClassificationEntity>
    {
        public int Create(EmployeeClassificationEntity classification, bool shouldRollBack)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var adapter = new DataAccessAdapter())
            {
                adapter.StartTransaction(IsolationLevel.ReadCommitted, null);
                adapter.SaveEntity(classification, true, recurse: false);
                var result = classification.EmployeeClassificationKey;

                if (shouldRollBack)
				{
					adapter.Rollback();
				}
                else
				{
					adapter.Commit();
				}
                return result;
            }
        }

        public int CreateWithIsolationLevel(EmployeeClassificationEntity classification, bool shouldRollBack, IsolationLevel isolationLevel)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var adapter = new DataAccessAdapter())
            {
                adapter.StartTransaction(isolationLevel, null);
                adapter.SaveEntity(classification, true, recurse: false);
                var result = classification.EmployeeClassificationKey;

                if (shouldRollBack)
				{
					adapter.Rollback();
				}
                else
				{
					adapter.Commit();
				}
                return result;
            }
        }

        public EmployeeClassificationEntity? GetByKey(int employeeClassificationKey)
        {
            using (var adapter = new DataAccessAdapter())
            {
                return new LinqMetaData(adapter).EmployeeClassification
												.FirstOrDefault(ec => ec.EmployeeClassificationKey == employeeClassificationKey);
            }
        }
    }
}
