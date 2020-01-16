using Recipes.Immutable;
using Recipes.RepoDb.Entities;
using RepoDb;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data.SqlClient;
using System.Linq;

namespace Recipes.RepoDb.Immutable
{
    public class ImmutableScenario : DbRepository<SqlConnection>,
        IImmutableScenario<ReadOnlyEmployeeClassification>
    {
        public ImmutableScenario(string connectionString)
            : base(connectionString)
        { }

        public int Create(ReadOnlyEmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            return Insert<EmployeeClassification, int>(new EmployeeClassification(classification));
        }

        public void Delete(ReadOnlyEmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            Delete(new EmployeeClassification(classification));
        }

        public void DeleteByKey(int employeeClassificationKey)
        {
            Delete<EmployeeClassification>(employeeClassificationKey);
        }

        public ReadOnlyEmployeeClassification? FindByName(string employeeClassificationName)
        {
            return Query<EmployeeClassification>(e => e.EmployeeClassificationName == employeeClassificationName)
                .FirstOrDefault()?
                .ToImmutable();
        }

        public IReadOnlyList<ReadOnlyEmployeeClassification> GetAll()
        {
            return QueryAll<EmployeeClassification>()
                .Select(e => e.ToImmutable())
                .ToImmutableList();
        }

        public ReadOnlyEmployeeClassification? GetByKey(int employeeClassificationKey)
        {
            return Query<EmployeeClassification>(employeeClassificationKey)
                .FirstOrDefault()?
                .ToImmutable();
        }

        public void Update(ReadOnlyEmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            base.Update<EmployeeClassification>(new EmployeeClassification(classification));
        }
    }
}
