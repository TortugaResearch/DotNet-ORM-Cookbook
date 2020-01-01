using Recipes.Immutable;
using System;
using System.Collections.Generic;
using Tortuga.Chain;

namespace Recipes.Chain.Immutable
{
    public class ImmutableRepository : IImmutableRepository<ReadOnlyEmployeeClassification>
    {
        const string TableName = "HR.EmployeeClassification";
        readonly SqlServerDataSource m_DataSource;

        public ImmutableRepository(SqlServerDataSource dataSource)
        {
            m_DataSource = dataSource;
        }

        public int Create(ReadOnlyEmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            return m_DataSource.Insert(classification).ToInt32().Execute();
        }

        public void Delete(ReadOnlyEmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            m_DataSource.Delete(classification).ToInt32().Execute();
        }

        public ReadOnlyEmployeeClassification? FindByName(string employeeClassificationName)
        {
            return m_DataSource.From(TableName, new { employeeClassificationName }).ToObject<ReadOnlyEmployeeClassification>(RowOptions.InferConstructor | RowOptions.AllowEmptyResults).Execute();
        }

        public IReadOnlyList<ReadOnlyEmployeeClassification> GetAll()
        {
            return m_DataSource.From(TableName).ToImmutableArray<ReadOnlyEmployeeClassification>(CollectionOptions.InferConstructor).Execute();
        }

        public ReadOnlyEmployeeClassification? GetByKey(int employeeClassificationKey)
        {
            return m_DataSource.GetByKey(TableName, employeeClassificationKey).ToObject<ReadOnlyEmployeeClassification>(RowOptions.InferConstructor).NeverNull().Execute();
        }

        public void Update(ReadOnlyEmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            m_DataSource.Update(classification).Execute();
        }
    }
}
