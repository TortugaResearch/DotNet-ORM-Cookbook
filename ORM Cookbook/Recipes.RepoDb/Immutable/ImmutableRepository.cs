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
    public class ImmutableRepository : DbRepository<SqlConnection>,
        IImmutableRepository<ReadOnlyEmployeeClassification>
    {
        public ImmutableRepository(string connectionString)
            : base(connectionString)
        { }

        public int Create(ReadOnlyEmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            return Insert<MutableEmployeeClassification, int>(new MutableEmployeeClassification(classification));
        }

        public void DeleteByKey(int employeeClassificationKey)
        {
            Delete<MutableEmployeeClassification>(employeeClassificationKey);
        }

        public void Delete(ReadOnlyEmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            Delete(new MutableEmployeeClassification(classification));
        }

        public ReadOnlyEmployeeClassification? FindByName(string employeeClassificationName)
        {
            return Query<MutableEmployeeClassification>(e => e.EmployeeClassificationName == employeeClassificationName)
                .FirstOrDefault()?
                .ToImmutable();
        }

        public IReadOnlyList<ReadOnlyEmployeeClassification> GetAll()
        {
            return QueryAll<MutableEmployeeClassification>()
                .Select(e => e.ToImmutable())
                .ToImmutableList();
        }

        public ReadOnlyEmployeeClassification? GetByKey(int employeeClassificationKey)
        {
            return Query<MutableEmployeeClassification>(employeeClassificationKey)
                .FirstOrDefault()?
                .ToImmutable();
        }

        public void Update(ReadOnlyEmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            base.Update<MutableEmployeeClassification>(new MutableEmployeeClassification(classification));
        }
    }
}
