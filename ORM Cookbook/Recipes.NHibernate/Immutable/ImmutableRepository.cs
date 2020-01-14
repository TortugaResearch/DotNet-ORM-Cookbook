using NHibernate;
using Recipes.Immutable;
using Recipes.NHibernate.Entities;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Recipes.NHibernate.Immutable
{
    public class ImmutableRepository : IImmutableRepository<ReadOnlyEmployeeClassification>
    {
        readonly ISessionFactory m_SessionFactory;

        public ImmutableRepository(ISessionFactory sessionFactory)
        {
            m_SessionFactory = sessionFactory;
        }

        public int Create(ReadOnlyEmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var session = m_SessionFactory.OpenSession())
            {
                var temp = classification.ToEntity();
                session.Save(temp);
                session.Flush();
                return temp.EmployeeClassificationKey;
            }
        }

        public void Delete(ReadOnlyEmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var session = m_SessionFactory.OpenSession())
            {
                session.Delete(classification.ToEntity());
                session.Flush();
            }
        }

        public ReadOnlyEmployeeClassification? FindByName(string employeeClassificationName)
        {
            using (var session = m_SessionFactory.OpenStatelessSession())
            {
                return session.QueryOver<EmployeeClassification>().Where(e => e.EmployeeClassificationName == employeeClassificationName).List()
                    .Select(x => new ReadOnlyEmployeeClassification(x)).SingleOrDefault();
            }
        }

        public IReadOnlyList<ReadOnlyEmployeeClassification> GetAll()
        {
            using (var session = m_SessionFactory.OpenStatelessSession())
            {
                return session.QueryOver<EmployeeClassification>().List()
                    .Select(x => new ReadOnlyEmployeeClassification(x)).ToImmutableArray();
            }
        }

        public ReadOnlyEmployeeClassification? GetByKey(int employeeClassificationKey)
        {
            using (var session = m_SessionFactory.OpenStatelessSession())
            {
                var result = session.Get<EmployeeClassification>(employeeClassificationKey);
                return new ReadOnlyEmployeeClassification(result);
            }
        }

        public void Update(ReadOnlyEmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var session = m_SessionFactory.OpenSession())
            {
                session.Update(classification.ToEntity());
                session.Flush();
            }
        }
    }
}
