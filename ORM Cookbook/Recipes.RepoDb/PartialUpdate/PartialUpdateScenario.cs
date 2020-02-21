using Microsoft.Data.SqlClient;
using Recipes.PartialUpdate;
using Recipes.RepoDb.Models;
using RDB = RepoDb;
using RepoDb;
using System;
using System.Linq;

namespace Recipes.RepoDb.PartialUpdate
{
    public class PartialUpdateScenario : BaseRepository<EmployeeClassification, SqlConnection>,
        IPartialUpdateScenario<EmployeeClassification>
    {
        public PartialUpdateScenario(string connectionString)
            : base(connectionString, RDB.Enumerations.ConnectionPersistency.Instance)
        { }

        public int Create(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            return Insert<int>(classification);
        }

        public EmployeeClassification? GetByKey(int employeeClassificationKey)
        {
            return Query(employeeClassificationKey).FirstOrDefault();
        }

        public void UpdateWithObject(EmployeeClassificationNameUpdater updateMessage)
        {
            if (updateMessage == null)
                throw new ArgumentNullException(nameof(updateMessage), $"{nameof(updateMessage)} is null.");

            using (var connection = CreateConnection(true))
            {
                connection.Update(ClassMappedNameCache.Get<EmployeeClassification>(), updateMessage);
            }
        }

        public void UpdateWithObject(EmployeeClassificationFlagsUpdater updateMessage)
        {
            if (updateMessage == null)
                throw new ArgumentNullException(nameof(updateMessage), $"{nameof(updateMessage)} is null.");

            using (var connection = CreateConnection(true))
            {
                connection.Update(ClassMappedNameCache.Get<EmployeeClassification>(), updateMessage);
            }
        }

        public void UpdateWithSeparateParameters(int employeeClassificationKey, bool isExempt, bool isEmployee)
        {
            using (var connection = CreateConnection(true))
            {
                connection.Update(ClassMappedNameCache.Get<EmployeeClassification>(),
                    new { employeeClassificationKey, isExempt, isEmployee });
            }
        }
    }
}
