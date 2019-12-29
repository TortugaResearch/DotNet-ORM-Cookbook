using Recipes.Chain.Models;
using Recipes.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tortuga.Chain;

namespace Recipes.Chain.Repositories
{
    public class EmployeeClassificationAsynchronousRepository : IEmployeeClassificationAsynchronousRepository<EmployeeClassification>
    {
        const string TableName = "HR.EmployeeClassification";
        readonly SqlServerDataSource m_DataSource;
        public EmployeeClassificationAsynchronousRepository(SqlServerDataSource dataSource)
        {
            m_DataSource = dataSource;
        }

        public async Task<int> CreateAsync(EmployeeClassification classification)
        {
            return await m_DataSource.Insert(classification).ToInt32().ExecuteAsync();
        }

        public async Task DeleteAsync(int employeeClassificationKey)
        {
            await m_DataSource.DeleteByKey(TableName, employeeClassificationKey).ExecuteAsync();
        }

        public async Task DeleteAsync(EmployeeClassification classification)
        {
            await m_DataSource.Delete(classification).ExecuteAsync();
        }

        public async Task<EmployeeClassification> FindByNameAsync(string employeeClassificationName)
        {
            return await m_DataSource.From(TableName, new { EmployeeClassificationName = employeeClassificationName }).ToObject<EmployeeClassification>().ExecuteAsync();
        }

        public async Task<IList<EmployeeClassification>> GetAllAsync()
        {
            return await m_DataSource.From(TableName).ToCollection<EmployeeClassification>().ExecuteAsync();
        }

        public async Task<EmployeeClassification> GetByKeyAsync(int employeeClassificationKey)
        {
            return await m_DataSource.GetByKey(TableName, employeeClassificationKey).ToObject<EmployeeClassification>().ExecuteAsync();
        }

        public async Task UpdateAsync(EmployeeClassification classification)
        {
            await m_DataSource.Update(classification).ExecuteAsync();
        }
    }
}
