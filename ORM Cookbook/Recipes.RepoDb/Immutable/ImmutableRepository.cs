using Recipes.Immutable;
using RepoDb;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data.SqlClient;
using System.Linq;

namespace Recipes.RepoDb.Immutable
{
    public class ImmutableRepository : BaseRepository<ReadOnlyEmployeeClassification, SqlConnection>,
        IImmutableRepository<ReadOnlyEmployeeClassification>
    {
        readonly string m_ConnectionString;

        public ImmutableRepository(string connectionString)
            : base(connectionString)
        {
            m_ConnectionString = connectionString;
        }

        public int Create(ReadOnlyEmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            return Insert<int>(classification);
        }

        public void DeleteByKey(int employeeClassificationKey)
        {
            Delete(e => e.EmployeeClassificationKey == employeeClassificationKey);
        }

        public void Delete(ReadOnlyEmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            Delete(classification);
        }

        public ReadOnlyEmployeeClassification? FindByName(string employeeClassificationName)
        {
            return Query(e => e.EmployeeClassificationName == employeeClassificationName)
                .FirstOrDefault();
        }

        public IReadOnlyList<ReadOnlyEmployeeClassification> GetAll()
        {
            return QueryAll().ToImmutableList();
        }

        public ReadOnlyEmployeeClassification? GetByKey(int employeeClassificationKey)
        {
            return Query(employeeClassificationKey).FirstOrDefault();
        }

        public void Update(ReadOnlyEmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            Update(classification);
        }
    }
}
