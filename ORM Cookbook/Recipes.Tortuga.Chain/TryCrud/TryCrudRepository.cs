using Recipes.TryCrud;
using System;
using Tortuga.Chain;

namespace Recipes.Chain.TryCrud
{
    public class TryCrudRepository : ITryCrudRepository<EmployeeClassification>
    {
        const string TableName = "HR.EmployeeClassification";
        readonly SqlServerDataSource m_DataSource;

        public TryCrudRepository(SqlServerDataSource dataSource)
        {
            m_DataSource = dataSource;
        }

        public int Create(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            return m_DataSource.Insert(classification).ToInt32().Execute();
        }

        public void DeleteByKeyOrException(int employeeClassificationKey)
        {
            var count = m_DataSource.DeleteByKey(TableName, employeeClassificationKey).Execute();
            if (count == 0)
                throw new MissingDataException();
        }

        public bool DeleteByKeyWithStatus(int employeeClassificationKey)
        {
            return 1 == m_DataSource.DeleteByKey(TableName, employeeClassificationKey).Execute();
        }

        public void DeleteOrException(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            var count = m_DataSource.Delete(classification).Execute();
            if (count == 0)
                throw new MissingDataException();
        }

        public bool DeleteWithStatus(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            return 1 == m_DataSource.Delete(classification).Execute();
        }

        public EmployeeClassification FindByNameOrException(string employeeClassificationName)
        {
            return m_DataSource.From(TableName, new { employeeClassificationName }).ToObject<EmployeeClassification>().NeverNull().Execute();
        }

        public EmployeeClassification? FindByNameOrNull(string employeeClassificationName)
        {
            return m_DataSource.From(TableName, new { employeeClassificationName }).ToObject<EmployeeClassification>(RowOptions.AllowEmptyResults).Execute();
        }

        public EmployeeClassification GetByKeyOrException(int employeeClassificationKey)
        {
            return m_DataSource.GetByKey(TableName, employeeClassificationKey).ToObject<EmployeeClassification>().NeverNull().Execute();
        }

        public EmployeeClassification? GetByKeyOrNull(int employeeClassificationKey)
        {
            return m_DataSource.GetByKey(TableName, employeeClassificationKey).ToObject<EmployeeClassification>(RowOptions.AllowEmptyResults).Execute();
        }

        public void UpdateOrException(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            m_DataSource.Update(classification).Execute();
        }

        public bool UpdateWithStatus(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            return 1 == m_DataSource.Update(classification, UpdateOptions.IgnoreRowsAffected).Execute();
        }
    }
}
