using Microsoft.Data.SqlClient;
using Recipes.RepoDb.Models;
using Recipes.SingleModelCrud;
using RDB = RepoDb;
using RepoDb;
using RepoDb.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.RepoDb.SingleModelCrud
{
    public class SingleModelCrudScenario : BaseRepository<EmployeeClassification, SqlConnection>,
        ISingleModelCrudScenario<EmployeeClassification>
    {
        public SingleModelCrudScenario(string connectionString)
            : base(connectionString, RDB.Enumerations.ConnectionPersistency.Instance)
        { }

        public int Create(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            return Insert<int>(classification);
        }

        public void Delete(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            base.Delete(classification);
        }

        public void DeleteByKey(int employeeClassificationKey)
        {
            Delete(employeeClassificationKey);
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
