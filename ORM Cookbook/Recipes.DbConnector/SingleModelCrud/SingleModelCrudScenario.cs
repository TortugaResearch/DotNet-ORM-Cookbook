using Recipes.DbConnector.Models;
using Recipes.SingleModelCrud;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.DbConnector.SingleModelCrud
{
    public class SingleModelCrudScenario : ScenarioBase, ISingleModelCrudScenario<EmployeeClassification>
    {
        public SingleModelCrudScenario(string connectionString) : base(connectionString)
        {
        }

        virtual public int Create(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            var sql = @"INSERT INTO HR.EmployeeClassification (EmployeeClassificationName)
                        OUTPUT Inserted.EmployeeClassificationKey
                        VALUES(@EmployeeClassificationName )";

            return DbConnector.Scalar<int>(sql, classification).Execute();
        }

        virtual public void Delete(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            var sql = @"DELETE HR.EmployeeClassification WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

            DbConnector.NonQuery(sql, classification).Execute();
        }

        public void DeleteByKey(int employeeClassificationKey)
        {
            var sql = @"DELETE HR.EmployeeClassification WHERE EmployeeClassificationKey = @employeeClassificationKey;";

            DbConnector.NonQuery(sql, new { employeeClassificationKey }).Execute();
        }

        public EmployeeClassification? FindByName(string employeeClassificationName)
        {
            var sql = @"SELECT	ec.EmployeeClassificationKey, ec.EmployeeClassificationName
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationName = @employeeClassificationName;";

            return DbConnector.ReadSingle<EmployeeClassification>(sql, new { employeeClassificationName }).Execute();
        }

        virtual public IList<EmployeeClassification> GetAll()
        {
            var sql = @"SELECT	ec.EmployeeClassificationKey, ec.EmployeeClassificationName FROM HR.EmployeeClassification ec;";

            return DbConnector.ReadToList<EmployeeClassification>(sql).Execute();
        }

        virtual public EmployeeClassification? GetByKey(int employeeClassificationKey)
        {
            var sql = @"SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationKey = @employeeClassificationKey;";

            return DbConnector.ReadSingle<EmployeeClassification>(sql, new { employeeClassificationKey }).Execute();
        }

        virtual public void Update(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            var sql = @"UPDATE HR.EmployeeClassification
                        SET EmployeeClassificationName = @EmployeeClassificationName
                        WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

            DbConnector.NonQuery(sql, classification).Execute();
        }
    }
}