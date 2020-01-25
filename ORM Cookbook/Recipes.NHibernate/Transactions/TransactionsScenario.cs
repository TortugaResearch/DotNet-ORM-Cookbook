using NHibernate;
using Recipes.NHibernate.Entities;
using Recipes.Transactions;
using System;
using System.Data;

namespace Recipes.NHibernate.Transactions
{
    public class TransactionsScenario : ITransactionsScenario<EmployeeClassification>
    {
        readonly ISessionFactory m_SessionFactory;

        public TransactionsScenario(ISessionFactory sessionFactory)
        {
            m_SessionFactory = sessionFactory;
        }

        public int Create(EmployeeClassification classification, bool shouldRollBack)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var session = m_SessionFactory.OpenSession())
            using (var trans = session.BeginTransaction())
            {
                session.Save(classification);
                session.Flush();
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

            using (var session = m_SessionFactory.OpenSession())
            using (var trans = session.BeginTransaction(isolationLevel))
            {
                session.Save(classification);
                session.Flush();
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
            using (var session = m_SessionFactory.OpenStatelessSession())
                return session.Get<EmployeeClassification>(employeeClassificationKey);
        }
    }
}
