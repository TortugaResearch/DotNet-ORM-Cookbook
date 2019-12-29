using Recipes.SingleModelCrudAsync;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tortuga.Chain;

namespace Recipes.Chain.SingleModelCrudAsync
{
    public class SingleModelCrudAsyncRepository : ISingleModelCrudAsyncRepository<EmployeeClassification>
    {
        const string TableName = "HR.EmployeeClassification";
        readonly SqlServerDataSource m_DataSource;

        public SingleModelCrudAsyncRepository(SqlServerDataSource dataSource)
        {
            m_DataSource = dataSource ?? throw new ArgumentNullException(nameof(dataSource), $"{nameof(dataSource)} is null.");
        }

        public Task<int> CreateAsync(EmployeeClassification classification)
        {
            return m_DataSource.Insert(classification).ToInt32().ExecuteAsync();
        }

        public Task DeleteAsync(EmployeeClassification classification)
        {
            return m_DataSource.Delete(classification).ExecuteAsync();
        }

        public Task DeleteByKeyAsync(int employeeClassificationKey)
        {
            return m_DataSource.DeleteByKey(TableName, employeeClassificationKey).ExecuteAsync();
        }

        public Task<EmployeeClassification?> FindByNameAsync(string employeeClassificationName)
        {
            return m_DataSource.From(TableName, new { EmployeeClassificationName = employeeClassificationName }).ToObject<EmployeeClassification>(RowOptions.AllowEmptyResults).ExecuteAsync();
        }

        public async Task<IList<EmployeeClassification>> GetAllAsync()
        {
            return await m_DataSource.From(TableName).ToCollection<EmployeeClassification>().ExecuteAsync().ConfigureAwait(false);
        }

        public Task<EmployeeClassification?> GetByKeyAsync(int employeeClassificationKey)
        {
            return m_DataSource.GetByKey(TableName, employeeClassificationKey).ToObject<EmployeeClassification>(RowOptions.AllowEmptyResults).ExecuteAsync();
        }

        public Task UpdateAsync(EmployeeClassification classification)
        {
            return m_DataSource.Update(classification).ExecuteAsync();
        }
    }
}
