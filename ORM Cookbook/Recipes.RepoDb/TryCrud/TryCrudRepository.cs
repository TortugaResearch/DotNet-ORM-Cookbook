using Recipes.RepoDb.Entities;
using Recipes.TryCrud;
using RepoDb;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Recipes.RepoDb.TryCrud
{
    public class TryCrudRepository : BaseRepository<EmployeeClassificationTryCrud, SqlConnection>,
        ITryCrudRepository<EmployeeClassificationTryCrud>
    {
        public TryCrudRepository(string connectionString)
            : base(connectionString)
        { }

        public int Create(EmployeeClassificationTryCrud classification)
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

        public void DeleteOrException(EmployeeClassificationTryCrud classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            var rowCount = Delete(classification);
            if (rowCount != 1)
                throw new DataException($"No row was found for key {classification.EmployeeClassificationKey}.");
        }

        public bool DeleteWithStatus(EmployeeClassificationTryCrud classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            return 1 == Delete(classification);
        }

        public EmployeeClassificationTryCrud FindByNameOrException(string employeeClassificationName)
        {
            var entity = Query(e => e.EmployeeClassificationName == employeeClassificationName).FirstOrDefault();
            if (null == entity)
                throw new DataException($"Message");

            return entity;
        }

        public EmployeeClassificationTryCrud? FindByNameOrNull(string employeeClassificationName)
        {
            return Query(e => e.EmployeeClassificationName == employeeClassificationName).FirstOrDefault();
        }

        public EmployeeClassificationTryCrud GetByKeyOrException(int employeeClassificationKey)
        {
            var entity = Query(employeeClassificationKey).FirstOrDefault();
            if (null == entity)
                throw new DataException($"Message");

            return entity;
        }

        public EmployeeClassificationTryCrud? GetByKeyOrNull(int employeeClassificationKey)
        {
            return Query(employeeClassificationKey).FirstOrDefault();
        }

        public void UpdateOrException(EmployeeClassificationTryCrud classification)
        {
            var rowCount = Update(classification);
            if (rowCount != 1)
                throw new DataException($"Message");
        }

        public bool UpdateWithStatus(EmployeeClassificationTryCrud classification)
        {
            return 1 == Update(classification);
        }
    }
}
