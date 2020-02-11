using Recipes.Chain.Models;
using Recipes.SingleModelCrudAsync;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Tortuga.Chain;

namespace Recipes.Chain.SingleModelCrudAsync
{
    public class SingleModelCrudAsyncScenario : ISingleModelCrudAsyncScenario<EmployeeClassification>
    {
        readonly SqlServerDataSource m_DataSource;

        public SingleModelCrudAsyncScenario(SqlServerDataSource dataSource)
        {
            m_DataSource = dataSource ??
                throw new ArgumentNullException(nameof(dataSource), $"{nameof(dataSource)} is null.");
        }

        public Task<int> CreateAsync(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            return m_DataSource.Insert(classification).ToInt32().ExecuteAsync();
        }

        public Task DeleteAsync(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            return m_DataSource.Delete(classification).ExecuteAsync();
        }

        public Task DeleteByKeyAsync(int employeeClassificationKey)
        {
            return m_DataSource.DeleteByKey<EmployeeClassification>(employeeClassificationKey).ExecuteAsync();
        }

        public Task<EmployeeClassification?> FindByNameAsync(string employeeClassificationName,
            CancellationToken cancellationToken = default)
        {
            return m_DataSource.From<EmployeeClassification>(new { employeeClassificationName })
                .ToObjectOrNull().ExecuteAsync(cancellationToken);
        }

        public async Task<IList<EmployeeClassification>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await m_DataSource.From<EmployeeClassification>().ToCollection().ExecuteAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        public Task<EmployeeClassification?> GetByKeyAsync(int employeeClassificationKey,
            CancellationToken cancellationToken = default)
        {
            return m_DataSource.GetByKey<EmployeeClassification>(employeeClassificationKey).ToObjectOrNull()
                .ExecuteAsync(cancellationToken);
        }

        public Task UpdateAsync(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            return m_DataSource.Update(classification).ExecuteAsync();
        }
    }
}
