using Recipes.SingleModelCrud;
using System.Collections.Generic;
using Tortuga.Chain;

namespace Recipes.Chain.SingleModelCrud
{
    public class SingleModelCrudRepository : ISingleModelCrudRepository<EmployeeClassification>
    {
        const string TableName = "HR.EmployeeClassification";
        readonly SqlServerDataSource m_DataSource;

        public SingleModelCrudRepository(SqlServerDataSource dataSource)
        {
            m_DataSource = dataSource;
        }

        public int Create(EmployeeClassification classification)
        {
            return m_DataSource.Insert(classification).ToInt32().Execute();
        }

        public void DeleteByKey(int employeeClassificationKey)
        {
            m_DataSource.DeleteByKey(TableName, employeeClassificationKey).Execute();
        }

        public void Delete(EmployeeClassification classification)
        {
            m_DataSource.Delete(classification).Execute();
        }

        public EmployeeClassification FindByName(string employeeClassificationName)
        {
            return m_DataSource.From(TableName, new { EmployeeClassificationName = employeeClassificationName }).ToObject<EmployeeClassification>().Execute()!;
        }

        public IList<EmployeeClassification> GetAll()
        {
            return m_DataSource.From(TableName).ToCollection<EmployeeClassification>().Execute();
        }

        public EmployeeClassification GetByKey(int employeeClassificationKey)
        {
            return m_DataSource.GetByKey(TableName, employeeClassificationKey).ToObject<EmployeeClassification>().Execute()!;
        }

        public void Update(EmployeeClassification classification)
        {
            m_DataSource.Update(classification).Execute();
        }
    }
}
