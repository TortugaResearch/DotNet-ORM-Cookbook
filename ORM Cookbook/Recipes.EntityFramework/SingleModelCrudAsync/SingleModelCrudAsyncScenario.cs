using Recipes.EntityFramework.Entities;
using Recipes.SingleModelCrudAsync;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Recipes.EntityFramework.SingleModelCrudAsync
{
    public class SingleModelCrudAsyncScenario : ISingleModelCrudAsyncScenario<EmployeeClassification>
    {
        private Func<OrmCookbookContext> CreateDbContext;

        public SingleModelCrudAsyncScenario(Func<OrmCookbookContext> dBContextFactory)
        {
            CreateDbContext = dBContextFactory;
        }

        public async Task<int> CreateAsync(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var context = CreateDbContext())
            {
                context.EmployeeClassification.Add(classification);
                await context.SaveChangesAsync().ConfigureAwait(false);
                return classification.EmployeeClassificationKey;
            }
        }

        public async Task DeleteAsync(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var context = CreateDbContext())
            {
                var temp = await context.EmployeeClassification.FindAsync(classification.EmployeeClassificationKey).ConfigureAwait(false);
                if (temp != null)
                {
                    context.EmployeeClassification.Remove(temp);
                    await context.SaveChangesAsync().ConfigureAwait(false);
                }
            }
        }

        public async Task DeleteByKeyAsync(int employeeClassificationKey)
        {
            using (var context = CreateDbContext())
            {
                var temp = await context.EmployeeClassification.FindAsync(employeeClassificationKey).ConfigureAwait(false);
                if (temp != null)
                {
                    context.EmployeeClassification.Remove(temp);
                    await context.SaveChangesAsync().ConfigureAwait(false);
                }
            }
        }

        public async Task<EmployeeClassification?> FindByNameAsync(string employeeClassificationName, CancellationToken cancellationToken = default)
        {
            using (var context = CreateDbContext())
            {
                return await context.EmployeeClassification.Where(ec => ec.EmployeeClassificationName == employeeClassificationName).SingleOrDefaultAsync(cancellationToken).ConfigureAwait(false);
            }
        }

        public async Task<IList<EmployeeClassification>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            using (var context = CreateDbContext())
            {
                return await context.EmployeeClassification.ToListAsync(cancellationToken).ConfigureAwait(false);
            }
        }

        public async Task<EmployeeClassification?> GetByKeyAsync(int employeeClassificationKey, CancellationToken cancellationToken = default)
        {
            using (var context = CreateDbContext())
            {
                //Note the cancellation token is before the parameters
                return await context.EmployeeClassification.FindAsync(cancellationToken, employeeClassificationKey).ConfigureAwait(false);
            }
        }

        public async Task UpdateAsync(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var context = CreateDbContext())
            {
                var temp = await context.EmployeeClassification.FindAsync(classification.EmployeeClassificationKey).ConfigureAwait(false);
                if (temp != null)
                {
                    temp.EmployeeClassificationName = classification.EmployeeClassificationName;
                    await context.SaveChangesAsync().ConfigureAwait(false);
                }
            }
        }
    }
}
