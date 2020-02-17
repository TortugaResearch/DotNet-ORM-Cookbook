using Microsoft.Data.SqlClient;
using Recipes.RepoDb.Models;
using Recipes.TryCrud;
using RDB = RepoDb;
using RepoDb;
using System;
using System.Data;
using System.Linq;

namespace Recipes.RepoDb.TryCrud
{
    public class TryCrudScenario : BaseRepository<EmployeeClassification, SqlConnection>,
        ITryCrudScenario<EmployeeClassification>
    {
        public TryCrudScenario(string connectionString)
            : base(connectionString, RDB.Enumerations.ConnectionPersistency.Instance)
        { }

        public int Create(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            return Insert<int>(classification);
        }

        public void DeleteByKeyOrException(int employeeClassificationKey)
        {
            var rowCount = Delete(employeeClassificationKey);
            if (rowCount != 1)
                throw new DataException($"No row was found for key {employeeClassificationKey}.");
        }

        public bool DeleteByKeyWithStatus(int employeeClassificationKey)
        {
            return 1 == Delete(employeeClassificationKey);
        }

        public void DeleteOrException(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            var rowCount = Delete(classification);
            if (rowCount != 1)
                throw new DataException($"No row was found for key {classification.EmployeeClassificationKey}.");
        }

        public bool DeleteWithStatus(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            return 1 == Delete(classification);
        }

        public EmployeeClassification FindByNameOrException(string employeeClassificationName)
        {
            var entity = Query(e => e.EmployeeClassificationName == employeeClassificationName).FirstOrDefault();
            if (null == entity)
                throw new DataException($"Message");

            return entity;
        }

        public EmployeeClassification? FindByNameOrNull(string employeeClassificationName)
        {
            return Query(e => e.EmployeeClassificationName == employeeClassificationName).FirstOrDefault();
        }

        public EmployeeClassification GetByKeyOrException(int employeeClassificationKey)
        {
            var entity = Query(employeeClassificationKey).FirstOrDefault();
            if (null == entity)
                throw new DataException($"Message");

            return entity;
        }

        public EmployeeClassification? GetByKeyOrNull(int employeeClassificationKey)
        {
            return Query(employeeClassificationKey).FirstOrDefault();
        }

        public void UpdateOrException(EmployeeClassification classification)
        {
            var rowCount = Update(classification);
            if (rowCount != 1)
                throw new DataException($"Message");
        }

        public bool UpdateWithStatus(EmployeeClassification classification)
        {
            return 1 == Update(classification);
        }
    }
}
