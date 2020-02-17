using Recipes.Immutable;
using Recipes.RepoDb.Models;
using RepoDb;
using RDB = RepoDb;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace Recipes.RepoDb.Immutable
{
    public class ImmutableScenario : BaseRepository<EmployeeClassification, SqlConnection>,
        IImmutableScenario<ReadOnlyEmployeeClassification>
    {
        public ImmutableScenario(string connectionString)
            : base(connectionString, RDB.Enumerations.ConnectionPersistency.Instance)
        { }

        public int Create(ReadOnlyEmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            return Insert<int>(new EmployeeClassification(classification));
        }

        public void Delete(ReadOnlyEmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            Delete(new EmployeeClassification(classification));
        }

        public void DeleteByKey(int employeeClassificationKey)
        {
            Delete(employeeClassificationKey);
        }

        public ReadOnlyEmployeeClassification? FindByName(string employeeClassificationName)
        {
            return Query(e => e.EmployeeClassificationName == employeeClassificationName)
                .FirstOrDefault()?
                .ToImmutable();
        }

        public IReadOnlyList<ReadOnlyEmployeeClassification> GetAll()
        {
            return QueryAll()
                .Select(e => e.ToImmutable())
                .ToImmutableList();
        }

        public ReadOnlyEmployeeClassification? GetByKey(int employeeClassificationKey)
        {
            return Query(employeeClassificationKey)
                .FirstOrDefault()?
                .ToImmutable();
        }

        public void Update(ReadOnlyEmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            base.Update(new EmployeeClassification(classification));
        }
    }
}
