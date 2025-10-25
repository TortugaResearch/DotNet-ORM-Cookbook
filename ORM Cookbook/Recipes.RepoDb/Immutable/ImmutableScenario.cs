using Microsoft.Data.SqlClient;
using Recipes.Immutable;
using Recipes.RepoDB.Models;
using RepoDb;
using System.Collections.Immutable;

using RDB = RepoDb;

namespace Recipes.RepoDB.Immutable
{
    public class ImmutableScenario(string connectionString) :
        IImmutableScenario<ReadOnlyEmployeeClassification>
    {
        public int Create(ReadOnlyEmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using var repository = new ReadOnlyEmployeeClassificationRepository(connectionString, RDB.Enumerations.ConnectionPersistency.Instance);

            return repository.Insert<int>(classification);
        }

        public void Delete(ReadOnlyEmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using var repository = new ReadOnlyEmployeeClassificationRepository(connectionString, RDB.Enumerations.ConnectionPersistency.Instance);

            repository.Delete(classification);
        }

        public void DeleteByKey(int employeeClassificationKey)
        {
            using var repository = new ReadOnlyEmployeeClassificationRepository(connectionString, RDB.Enumerations.ConnectionPersistency.Instance);

            repository.Delete(employeeClassificationKey);
        }

        public ReadOnlyEmployeeClassification? FindByName(string employeeClassificationName)
        {
            using var repository = new ReadOnlyEmployeeClassificationRepository(connectionString, RDB.Enumerations.ConnectionPersistency.Instance);

            return repository.Query(e => e.EmployeeClassificationName == employeeClassificationName)
                .FirstOrDefault();
        }

        public IReadOnlyList<ReadOnlyEmployeeClassification> GetAll()
        {
            using var repository = new ReadOnlyEmployeeClassificationRepository(connectionString, RDB.Enumerations.ConnectionPersistency.Instance);

            return repository.QueryAll()
                .ToImmutableList();
        }

        public ReadOnlyEmployeeClassification? GetByKey(int employeeClassificationKey)
        {
            using var repository = new ReadOnlyEmployeeClassificationRepository(connectionString, RDB.Enumerations.ConnectionPersistency.Instance);

            return repository.Query(employeeClassificationKey)
                .FirstOrDefault();
        }

        public void Update(ReadOnlyEmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using var repository = new ReadOnlyEmployeeClassificationRepository(connectionString, RDB.Enumerations.ConnectionPersistency.Instance);

            repository.Update(classification);
        }
    }
}