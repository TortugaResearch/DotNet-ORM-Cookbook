using Microsoft.EntityFrameworkCore;
using Recipes.EntityFrameworkCore.Entities;
using Recipes.SingleModelCrudAsync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Recipes.EntityFrameworkCore.SingleModelCrudAsync
{
    public class SingleModelCrudAsyncRepository : ISingleModelCrudAsyncRepository<EmployeeClassification>
    {
        private Func<OrmCookbookContext> CreateDbContext;

        public SingleModelCrudAsyncRepository(Func<OrmCookbookContext> dBContextFactory)
        {
            CreateDbContext = dBContextFactory;
        }

        public async Task<int> CreateAsync(EmployeeClassification classification)
        {
            using (var context = CreateDbContext())
            {
                context.EmployeeClassification.Add(classification);
                await context.SaveChangesAsync().ConfigureAwait(false);
                return classification.EmployeeClassificationKey;
            }
        }

        public async Task DeleteAsync(EmployeeClassification classification)
        {
            using (var context = CreateDbContext())
            {
                var temp = await context.EmployeeClassification.FindAsync(classification.EmployeeClassificationKey);
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
                var temp = await context.EmployeeClassification.FindAsync(employeeClassificationKey);
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
                return await context.EmployeeClassification.FindAsync(new object[] { employeeClassificationKey }, cancellationToken);
            }
        }

        public async Task UpdateAsync(EmployeeClassification classification)
        {
            using (var context = CreateDbContext())
            {
                var temp = await context.EmployeeClassification.FindAsync(classification.EmployeeClassificationKey);
                temp.EmployeeClassificationName = classification.EmployeeClassificationName;
                await context.SaveChangesAsync().ConfigureAwait(false);
            }
        }
    }
}
