using Microsoft.Data.SqlClient;
using Recipes.Immutable;
using Recipes.RepoDB.Models;
using RepoDb;
using System.Collections.Immutable;

using RDB = RepoDb;

namespace Recipes.RepoDB.Immutable
{
    public class ImmutableScenario : BaseRepository<ReadOnlyEmployeeClassification, SqlConnection>,
        IImmutableScenario<ReadOnlyEmployeeClassification>
    {
        public ImmutableScenario(string connectionString)
            : base(connectionString, RDB.Enumerations.ConnectionPersistency.Instance)
        { }

        public int Create(ReadOnlyEmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            return Insert<int>(classification);
        }

        public void Delete(ReadOnlyEmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            base.Delete(classification);
        }

        public void DeleteByKey(int employeeClassificationKey)
        {
            Delete(employeeClassificationKey);
        }

        public ReadOnlyEmployeeClassification? FindByName(string employeeClassificationName)
        {
            return Query(e => e.EmployeeClassificationName == employeeClassificationName)
                .FirstOrDefault();
        }

        public IReadOnlyList<ReadOnlyEmployeeClassification> GetAll()
        {
            return QueryAll()
                .ToImmutableList();
        }

        public ReadOnlyEmployeeClassification? GetByKey(int employeeClassificationKey)
        {
            return Query(employeeClassificationKey)
                .FirstOrDefault();
        }

        public void Update(ReadOnlyEmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            base.Update(classification);
        }
    }
}