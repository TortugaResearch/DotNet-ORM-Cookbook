using NHibernate;
using NHibernate.Criterion;
using Recipes.NHibernate.Entities;
using Recipes.TryCrud;
using System;
using System.Data;
using System.Linq;

namespace Recipes.NHibernate.TryCrud
{
    public class TryCrudRepository : ITryCrudRepository<EmployeeClassification>
    {
        readonly ISessionFactory m_SessionFactory;

        public TryCrudRepository(ISessionFactory sessionFactory)
        {
            m_SessionFactory = sessionFactory;
        }

        public int Create(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var session = m_SessionFactory.OpenSession())
            {
                session.Save(classification);
                session.Flush();
                return classification.EmployeeClassificationKey;
            }
        }

        public void DeleteByKeyOrException(int employeeClassificationKey)
        {
            using (var session = m_SessionFactory.OpenSession())
            {
                var temp = session.Get<EmployeeClassification>(employeeClassificationKey);
                session.Delete(temp);
                session.Flush();
            }
        }

        public bool DeleteByKeyWithStatus(int employeeClassificationKey)
        {
            using (var session = m_SessionFactory.OpenSession())
            {
                var temp = session.Get<EmployeeClassification>(employeeClassificationKey);
                if (temp == null)
                    return false;
                session.Delete(temp);
                session.Flush();
                return true;
            }
        }

        public void DeleteOrException(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var session = m_SessionFactory.OpenSession())
            {
                session.Delete(classification);
                session.Flush();
            }
        }

        public bool DeleteWithStatus(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var session = m_SessionFactory.OpenSession())
            {
                try
                {
                    session.Delete(classification);
                    session.Flush();
                    return true;
                }
                catch (StaleStateException ex) when (ex.Message.Contains("Batch update returned unexpected row count from update;", StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }
        }

        public EmployeeClassification FindByNameOrException(string employeeClassificationName)
        {
            using (var session = m_SessionFactory.OpenStatelessSession())
            {
                return session
                    .CreateCriteria(typeof(EmployeeClassification))
                    .Add(Restrictions.Eq("EmployeeClassificationName", employeeClassificationName))
                    .List<EmployeeClassification>()
                    .Single();
            }
        }

        public EmployeeClassification? FindByNameOrNull(string employeeClassificationName)
        {
            using (var session = m_SessionFactory.OpenStatelessSession())
            {
                return session
                    .CreateCriteria(typeof(EmployeeClassification))
                    .Add(Restrictions.Eq("EmployeeClassificationName", employeeClassificationName))
                    .List<EmployeeClassification>()
                    .SingleOrDefault();
            }
        }

        public EmployeeClassification GetByKeyOrException(int employeeClassificationKey)
        {
            using (var session = m_SessionFactory.OpenStatelessSession())
                return session.Get<EmployeeClassification>(employeeClassificationKey) ?? throw new DataException($"No row was found for key {employeeClassificationKey}."); ;
        }

        public EmployeeClassification? GetByKeyOrNull(int employeeClassificationKey)
        {
            using (var session = m_SessionFactory.OpenStatelessSession())
                return session.Get<EmployeeClassification>(employeeClassificationKey);
        }

        public void UpdateOrException(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var session = m_SessionFactory.OpenSession())
            {
                session.Update(classification);
                session.Flush();
            }
        }

        public bool UpdateWithStatus(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var session = m_SessionFactory.OpenSession())
            {
                try
                {
                    session.Update(classification);
                    session.Flush();
                    return true;
                }
                catch (StaleStateException ex) when (ex.Message.Contains("Batch update returned unexpected row count from update;", StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }
        }
    }
}
