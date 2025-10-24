using Microsoft.EntityFrameworkCore;
using Recipes.EntityFrameworkCore.Entities;
using Recipes.SingleModelCrudAsync;

namespace Recipes.EntityFrameworkCore.SingleModelCrudAsync
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
                context.EmployeeClassifications.Add(classification);
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
                var temp = await context.EmployeeClassifications.FindAsync(classification.EmployeeClassificationKey).ConfigureAwait(false);
                if (temp != null)
                {
                    context.EmployeeClassifications.Remove(temp);
                    await context.SaveChangesAsync().ConfigureAwait(false);
                }
            }
        }

        public async Task DeleteByKeyAsync(int employeeClassificationKey)
        {
            using (var context = CreateDbContext())
            {
                var temp = await context.EmployeeClassifications.FindAsync(employeeClassificationKey).ConfigureAwait(false);
                if (temp != null)
                {
                    context.EmployeeClassifications.Remove(temp);
                    await context.SaveChangesAsync().ConfigureAwait(false);
                }
            }
        }

        public async Task<EmployeeClassification?> FindByNameAsync(string employeeClassificationName, CancellationToken cancellationToken = default)
        {
            using (var context = CreateDbContext())
            {
                return await context.EmployeeClassifications.Where(ec => ec.EmployeeClassificationName == employeeClassificationName).SingleOrDefaultAsync(cancellationToken).ConfigureAwait(false);
            }
        }

        public async Task<IList<EmployeeClassification>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            using (var context = CreateDbContext())
            {
                return await context.EmployeeClassifications.ToListAsync(cancellationToken).ConfigureAwait(false);
            }
        }

        public async Task<EmployeeClassification?> GetByKeyAsync(int employeeClassificationKey, CancellationToken cancellationToken = default)
        {
            using (var context = CreateDbContext())
            {
                return await context.EmployeeClassifications.FindAsync(new object[] { employeeClassificationKey }, cancellationToken).ConfigureAwait(false);
            }
        }

        public async Task UpdateAsync(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var context = CreateDbContext())
            {
                var temp = await context.EmployeeClassifications.FindAsync(classification.EmployeeClassificationKey).ConfigureAwait(false);
                if (temp != null)
                {
                    temp.EmployeeClassificationName = classification.EmployeeClassificationName;
                    await context.SaveChangesAsync().ConfigureAwait(false);
                }
            }
        }
    }
}