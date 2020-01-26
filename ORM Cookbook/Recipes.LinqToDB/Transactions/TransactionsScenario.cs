using LinqToDB;
using Recipes.LinqToDB.Entities;
using Recipes.Transactions;
using System.Data;
using System.Linq;

namespace Recipes.LinqToDB.Transactions
{
    public class TransactionsScenario : ITransactionsScenario<EmployeeClassification>
    {
        public int Create(EmployeeClassification classification, bool shouldRollBack)
        {
            using (var db = new OrmCookbook())
            using (var trans = db.BeginTransaction())
            {
                var result = db.InsertWithInt32Identity(classification);

                if (shouldRollBack)
                    trans.Rollback();
                else
                    trans.Commit();

                return result;
            }
        }

        public int CreateWithIsolationLevel(EmployeeClassification classification, bool shouldRollBack, IsolationLevel isolationLevel)
        {
            using (var db = new OrmCookbook())
            using (var trans = db.BeginTransaction(isolationLevel))
            {
                var result = db.InsertWithInt32Identity(classification);

                if (shouldRollBack)
                    trans.Rollback();
                else
                    trans.Commit();

                return result;
            }
        }

        public EmployeeClassification? GetByKey(int employeeClassificationKey)
        {
            using (var db = new OrmCookbook())
            {
                return db.EmployeeClassification.Where(d => d.EmployeeClassificationKey == employeeClassificationKey).SingleOrDefault();
            }
        }
    }
}
