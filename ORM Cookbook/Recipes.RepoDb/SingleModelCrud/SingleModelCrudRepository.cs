using Recipes.SingleModelCrud;
using RepoDb;
using RepoDb.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Recipes.RepoDb.SingleModelCrud
{
    public class SingleModelCrudRepository : BaseRepository<EmployeeClassification, SqlConnection>,
        ISingleModelCrudRepository<EmployeeClassification>
    {
        public SingleModelCrudRepository(string connectionString)
            : base(connectionString)
        { }

        public int Create(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            return Insert<int>(classification);
        }

        public void DeleteByKey(int employeeClassificationKey)
        {
            Delete(employeeClassificationKey);
        }

        public void Delete(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            base.Delete(classification);
        }

        public EmployeeClassification? FindByName(string employeeClassificationName)
        {
            return Query(e => e.EmployeeClassificationName == employeeClassificationName).FirstOrDefault();
        }

        public IList<EmployeeClassification> GetAll()
        {
            return QueryAll().AsList();
        }

        public EmployeeClassification? GetByKey(int employeeClassificationKey)
        {
            return Query(employeeClassificationKey).FirstOrDefault();
        }

        public void Update(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            base.Update(classification);
        }
    }
}
