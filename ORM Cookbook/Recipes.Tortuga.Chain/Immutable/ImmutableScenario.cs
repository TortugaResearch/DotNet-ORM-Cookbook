using Recipes.Chain.Models;
using Recipes.Immutable;
using System;
using System.Collections.Generic;
using Tortuga.Chain;

namespace Recipes.Chain.Immutable
{
    public class ImmutableScenario : IImmutableScenario<ReadOnlyEmployeeClassification>
    {
        readonly SqlServerDataSource m_DataSource;

        public ImmutableScenario(SqlServerDataSource dataSource)
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

            m_DataSource.Delete(classification).Execute();
        }

        public ReadOnlyEmployeeClassification? FindByName(string employeeClassificationName)
        {
            return m_DataSource.From<ReadOnlyEmployeeClassification>(new { employeeClassificationName })
                .ToObjectOrNull(RowOptions.InferConstructor).Execute();
        }

        public IReadOnlyList<ReadOnlyEmployeeClassification> GetAll()
        {
            return m_DataSource.From<ReadOnlyEmployeeClassification>()
                .ToImmutableArray(CollectionOptions.InferConstructor).Execute();
        }

        public ReadOnlyEmployeeClassification? GetByKey(int employeeClassificationKey)
        {
            return m_DataSource.GetByKey<ReadOnlyEmployeeClassification>(employeeClassificationKey)
                .ToObjectOrNull<ReadOnlyEmployeeClassification>(RowOptions.InferConstructor).Execute();
        }

        public void Update(ReadOnlyEmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            m_DataSource.Update(classification).Execute();
        }
    }
}
