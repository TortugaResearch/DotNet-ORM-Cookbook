using Recipes.SingleModelCrud;
using RepoDb;
using RepoDb.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Recipes.RepoDb.SingleModelCrud
{
    public class SingleModelCrudRepository : BaseRepository<EmployeeClassificationSingleModelCrud, SqlConnection>,
        ISingleModelCrudRepository<EmployeeClassificationSingleModelCrud>
    {
        public SingleModelCrudRepository(string connectionString)
            : base(connectionString)
        { }

        public int Create(EmployeeClassificationSingleModelCrud classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            return Insert<int>(classification);
        }

        public void DeleteByKey(int employeeClassificationKey)
        {
            Delete(employeeClassificationKey);
        }

        public void Delete(EmployeeClassificationSingleModelCrud classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            base.Delete(classification);
        }

        public EmployeeClassificationSingleModelCrud? FindByName(string employeeClassificationName)
        {
            return Query(e => e.EmployeeClassificationName == employeeClassificationName).FirstOrDefault();
        }

        public IList<EmployeeClassificationSingleModelCrud> GetAll()
        {
            return QueryAll().AsList();
        }

        public EmployeeClassificationSingleModelCrud? GetByKey(int employeeClassificationKey)
        {
            return Query(employeeClassificationKey).FirstOrDefault();
        }

        public void Update(EmployeeClassificationSingleModelCrud classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            base.Update(classification);
        }
    }
}
