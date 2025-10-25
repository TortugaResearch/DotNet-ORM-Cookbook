using Recipes.Immutable;
using Recipes.RepoDB.Models;
using RepoDb.Enumerations;
using System.Collections.Immutable;

namespace Recipes.RepoDB.Immutable
{
    public class ImmutableScenario : IImmutableScenario<ReadOnlyEmployeeClassification>
    {
        readonly string m_ConnectionString;

        public ImmutableScenario(string connectionString)
        {
            m_ConnectionString = connectionString;
        }

        public int Create(ReadOnlyEmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var repository = new ReadOnlyEmployeeClassificationRepository(m_ConnectionString, ConnectionPersistency.Instance))
            return repository.Insert<int>(classification);
        }

        public void Delete(ReadOnlyEmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var repository = new ReadOnlyEmployeeClassificationRepository(m_ConnectionString, ConnectionPersistency.Instance))
            repository.Delete(classification);
        }

        public void DeleteByKey(int employeeClassificationKey)
        {
            using (var repository = new ReadOnlyEmployeeClassificationRepository(m_ConnectionString, ConnectionPersistency.Instance))
            repository.Delete(employeeClassificationKey);
        }

        public ReadOnlyEmployeeClassification? FindByName(string employeeClassificationName)
        {
            using (var repository = new ReadOnlyEmployeeClassificationRepository(m_ConnectionString, ConnectionPersistency.Instance))
            return repository.Query(e => e.EmployeeClassificationName == employeeClassificationName)
                .FirstOrDefault();
        }

        public IReadOnlyList<ReadOnlyEmployeeClassification> GetAll()
        {
            using (var repository = new ReadOnlyEmployeeClassificationRepository(m_ConnectionString, ConnectionPersistency.Instance))
            return repository.QueryAll()
                .ToImmutableList();
        }

        public ReadOnlyEmployeeClassification? GetByKey(int employeeClassificationKey)
        {
            using (var repository = new ReadOnlyEmployeeClassificationRepository(m_ConnectionString, ConnectionPersistency.Instance))
            return repository.Query(employeeClassificationKey)
                .FirstOrDefault();
        }

        public void Update(ReadOnlyEmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var repository = new ReadOnlyEmployeeClassificationRepository(m_ConnectionString, ConnectionPersistency.Instance))
            repository.Update(classification);
        }
    }
}