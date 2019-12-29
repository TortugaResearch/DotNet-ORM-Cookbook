using NHibernate;
using NHibernate.Criterion;
using Recipes.NHibernate.Models;
using Recipes.SingleModelCrudAsync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Recipes.NHibernate.SingleModelCrudAsync
{
    public class SingleModelCrudAsyncRepository : ISingleModelCrudAsyncRepository<EmployeeClassification>
    {
        readonly ISessionFactory m_SessionFactory;

        public SingleModelCrudAsyncRepository(ISessionFactory sessionFactory)
        {
            m_SessionFactory = sessionFactory;
        }

        public async Task<int> CreateAsync(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var session = m_SessionFactory.OpenSession())
            {
                await session.SaveAsync(classification).ConfigureAwait(false);
                await session.FlushAsync().ConfigureAwait(false);
                return classification.EmployeeClassificationKey;
            }
        }

        public async Task DeleteAsync(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var session = m_SessionFactory.OpenSession())
            {
                await session.DeleteAsync(classification).ConfigureAwait(false);
                await session.FlushAsync().ConfigureAwait(false);
            }
        }

        public async Task DeleteByKeyAsync(int employeeClassificationKey)
        {
            using (var session = m_SessionFactory.OpenSession())
            {
                var temp = session.Get<EmployeeClassification>(employeeClassificationKey);
                await session.DeleteAsync(temp).ConfigureAwait(false);
                await session.FlushAsync().ConfigureAwait(false);
            }
        }

        public async Task<EmployeeClassification?> FindByNameAsync(string employeeClassificationName, CancellationToken cancellationToken = default)
        {
            using (var session = m_SessionFactory.OpenStatelessSession())
            {
                return (await session
                    .CreateCriteria(typeof(EmployeeClassification))
                    .Add(Restrictions.Eq("EmployeeClassificationName", employeeClassificationName))
                    .ListAsync<EmployeeClassification>(cancellationToken)
                    .ConfigureAwait(false))
                    .SingleOrDefault();
            }
        }

        public async Task<IList<EmployeeClassification>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            using (var session = m_SessionFactory.OpenStatelessSession())
            {
                return await session
                    .CreateCriteria(typeof(EmployeeClassification))
                    .ListAsync<EmployeeClassification>(cancellationToken).ConfigureAwait(false);
            }
        }

        public async Task<EmployeeClassification?> GetByKeyAsync(int employeeClassificationKey, CancellationToken cancellationToken = default)
        {
            using (var session = m_SessionFactory.OpenStatelessSession())
                return await session.GetAsync<EmployeeClassification>(employeeClassificationKey, cancellationToken).ConfigureAwait(false);
        }

        public async Task UpdateAsync(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var session = m_SessionFactory.OpenSession())
            {
                await session.UpdateAsync(classification).ConfigureAwait(false);
                await session.FlushAsync().ConfigureAwait(false);
            }
        }
    }
}
