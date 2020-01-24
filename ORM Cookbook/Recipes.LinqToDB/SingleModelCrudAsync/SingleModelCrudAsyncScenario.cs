using LinqToDB;
using Recipes.LinqToDB.Entities;
using Recipes.SingleModelCrudAsync;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Recipes.LinqToDB.SingleModelCrudAsync
{
    public class SingleModelCrudAsyncScenario : ISingleModelCrudAsyncScenario<EmployeeClassification>
    {
        public async Task<int> CreateAsync(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var db = new OrmCookbook())
            {
                return await db.InsertWithInt32IdentityAsync(classification).ConfigureAwait(false);
            }
        }

        public async Task DeleteAsync(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var db = new OrmCookbook())
            {
                await db.EmployeeClassification
                    .Where(d => d.EmployeeClassificationKey == classification.EmployeeClassificationKey)
                    .DeleteAsync().ConfigureAwait(false);
            }
        }

        public async Task DeleteByKeyAsync(int employeeClassificationKey)
        {
            using (var db = new OrmCookbook())
            {
                await db.EmployeeClassification
                    .Where(d => d.EmployeeClassificationKey == employeeClassificationKey)
                    .DeleteAsync().ConfigureAwait(false);
            }
        }

        public async Task<EmployeeClassification?> FindByNameAsync(string employeeClassificationName, CancellationToken cancellationToken = default)
        {
            using (var db = new OrmCookbook())
            {
                var query = from ec in db.EmployeeClassification
                            where ec.EmployeeClassificationName == employeeClassificationName
                            select ec;
                return await query.SingleAsync().ConfigureAwait(false);
            }
        }

        public async Task<IList<EmployeeClassification>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            using (var db = new OrmCookbook())
            {
                return await db.EmployeeClassification.ToListAsync().ConfigureAwait(false);
            }
        }

        public async Task<EmployeeClassification?> GetByKeyAsync(int employeeClassificationKey, CancellationToken cancellationToken = default)
        {
            using (var db = new OrmCookbook())
            {
                return await db.EmployeeClassification.Where(d => d.EmployeeClassificationKey == employeeClassificationKey).SingleAsync().ConfigureAwait(false);
            }
        }

        public async Task UpdateAsync(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var db = new OrmCookbook())
            {
                await db.UpdateAsync(classification).ConfigureAwait(false);
            }
        }
    }
}
