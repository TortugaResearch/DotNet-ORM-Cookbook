using Recipes.Xpo.Entities;
using Recipes.SingleModelCrudAsync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DevExpress.Xpo;

namespace Recipes.Xpo.SingleModelCrudAsync
{
    public class SingleModelCrudAsyncScenario : ISingleModelCrudAsyncScenario<EmployeeClassification>
    {
        public async Task<int> CreateAsync(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");
            await Session.DefaultSession.ExplicitBeginTransactionAsync().ConfigureAwait(false);
            classification.Save();
            await Session.DefaultSession.ExplicitCommitTransactionAsync().ConfigureAwait(false);
            return classification.EmployeeClassificationKey;
        }

        public async Task DeleteAsync(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            await Session.DefaultSession.ExplicitBeginTransactionAsync().ConfigureAwait(false);
            classification.Delete();
            await Session.DefaultSession.ExplicitCommitTransactionAsync().ConfigureAwait(false);
        }

        public async Task DeleteByKeyAsync(int employeeClassificationKey)
        {

            using (var uow = new UnitOfWork())
            {
                var temp = await uow.GetObjectByKeyAsync<EmployeeClassification>(employeeClassificationKey).ConfigureAwait(false);
                if (temp != null)
                {
                    uow.Delete(temp);
                    await uow.CommitChangesAsync().ConfigureAwait(false);
                }
            }
        }

        public async Task<EmployeeClassification?> FindByNameAsync(string employeeClassificationName, CancellationToken cancellationToken = default)
        {
            return await Session.DefaultSession.Query<EmployeeClassification>().Where(ec => ec.EmployeeClassificationName == employeeClassificationName).SingleOrDefaultAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<IList<EmployeeClassification>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await Session.DefaultSession.Query<EmployeeClassification>().ToListAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<EmployeeClassification?> GetByKeyAsync(int employeeClassificationKey, CancellationToken cancellationToken = default)
        {
            return await Session.DefaultSession.GetObjectByKeyAsync<EmployeeClassification>(employeeClassificationKey, cancellationToken).ConfigureAwait(false);
        }

        public async Task UpdateAsync(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            await Session.DefaultSession.ExplicitBeginTransactionAsync().ConfigureAwait(false);
            classification.Save();

            await Session.DefaultSession.ExplicitCommitTransactionAsync().ConfigureAwait(false);
        }
    }
}
