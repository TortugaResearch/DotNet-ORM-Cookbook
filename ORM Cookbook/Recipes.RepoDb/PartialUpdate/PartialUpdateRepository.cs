using Recipes.PartialUpdate;
using RepoDb;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace Recipes.RepoDb.PartialUpdate
{
    public class PartialUpdateRepository : BaseRepository<EmployeeClassificationPartialUpdate, SqlConnection>,
        IPartialUpdateRepository<EmployeeClassificationPartialUpdate>
    {
        public PartialUpdateRepository(string connectionString)
            : base(connectionString)
        { }

        public int Create(EmployeeClassificationPartialUpdate classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            return Insert<int>(classification);
        }

        public EmployeeClassificationPartialUpdate? GetByKey(int employeeClassificationKey)
        {
            return Query(employeeClassificationKey).FirstOrDefault();
        }

        public void UpdateWithObject(EmployeeClassificationNameUpdater updateMessage)
        {
            if (updateMessage == null)
                throw new ArgumentNullException(nameof(updateMessage), $"{nameof(updateMessage)} is null.");

            using (var connection = CreateConnection(true))
            {
                connection.Update(ClassMappedNameCache.Get<EmployeeClassificationPartialUpdate>(), updateMessage);
            }
        }

        public void UpdateWithObject(EmployeeClassificationFlagsUpdater updateMessage)
        {
            if (updateMessage == null)
                throw new ArgumentNullException(nameof(updateMessage), $"{nameof(updateMessage)} is null.");

            using (var connection = CreateConnection(true))
            {
                connection.Update(ClassMappedNameCache.Get<EmployeeClassificationPartialUpdate>(), updateMessage);
            }
        }

        public void UpdateWithSeparateParameters(int employeeClassificationKey, bool isExempt, bool isEmployee)
        {
            using (var connection = CreateConnection(true))
            {
                connection.Update(ClassMappedNameCache.Get<EmployeeClassificationPartialUpdate>(),
                    new { employeeClassificationKey, isExempt, isEmployee });
            }
        }
    }
}
