using Dapper;
using Dapper.Contrib.Extensions;
using Recipes.Dapper.Models;
using Recipes.TryCrud;
using System;
using System.Data;

namespace Recipes.Dapper.TryCrud
{
    public class TryCrudScenario : ScenarioBase, ITryCrudScenario<EmployeeClassification>
    {
        public TryCrudScenario(string connectionString) : base(connectionString)
        {
        }

        public int Create(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var con = OpenConnection())
                return (int)con.Insert(classification);
        }

        public void DeleteByKeyOrException(int employeeClassificationKey)
        {
            var sql = @"DELETE HR.EmployeeClassification WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = OpenConnection())
            {
                var rowCount = con.Execute(sql, new { employeeClassificationKey });
                if (rowCount != 1)
                    throw new DataException($"No row was found for key {employeeClassificationKey}.");
            }
        }

        public bool DeleteByKeyWithStatus(int employeeClassificationKey)
        {
            var sql = @"DELETE HR.EmployeeClassification WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = OpenConnection())
                return 1 == con.Execute(sql, new { employeeClassificationKey });
        }

        public void DeleteOrException(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            var sql = @"DELETE HR.EmployeeClassification WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = OpenConnection())
            {
                var rowCount = con.Execute(sql, classification);
                if (rowCount != 1)
                    throw new DataException($"No row was found for key {classification.EmployeeClassificationKey}.");
            }
        }

        public bool DeleteWithStatus(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            var sql = @"DELETE HR.EmployeeClassification WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = OpenConnection())
                return 1 == con.Execute(sql, classification);
        }

        public EmployeeClassification FindByNameOrException(string employeeClassificationName)
        {
            var sql = @"SELECT	ec.EmployeeClassificationKey, ec.EmployeeClassificationName
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationName = @EmployeeClassificationName;";

            using (var con = OpenConnection())
                return con.QuerySingle<EmployeeClassification>(sql, new { employeeClassificationName });
        }

        public EmployeeClassification? FindByNameOrNull(string employeeClassificationName)
        {
            var sql = @"SELECT	ec.EmployeeClassificationKey, ec.EmployeeClassificationName
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationName = @EmployeeClassificationName;";

            using (var con = OpenConnection())
                return con.QuerySingleOrDefault<EmployeeClassification>(sql, new { employeeClassificationName });
        }

        public EmployeeClassification GetByKeyOrException(int employeeClassificationKey)
        {
            var sql = @"SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = OpenConnection())
                return con.QuerySingle<EmployeeClassification>(sql, new { employeeClassificationKey });
        }

        public EmployeeClassification? GetByKeyOrNull(int employeeClassificationKey)
        {
            var sql = @"SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName
                        FROM HR.EmployeeClassification ec
                        WHERE ec.EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = OpenConnection())
                return con.QuerySingleOrDefault<EmployeeClassification>(sql, new { employeeClassificationKey });
        }

        public void UpdateOrException(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            var sql = @"UPDATE HR.EmployeeClassification
                        SET EmployeeClassificationName = @EmployeeClassificationName
                        WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = OpenConnection())
            {
                var rowCount = con.Execute(sql, classification);
                if (rowCount != 1)
                    throw new DataException($"No row was found for key {classification.EmployeeClassificationKey}.");
            }
        }

        public bool UpdateWithStatus(EmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            var sql = @"UPDATE HR.EmployeeClassification
                        SET EmployeeClassificationName = @EmployeeClassificationName
                        WHERE EmployeeClassificationKey = @EmployeeClassificationKey;";

            using (var con = OpenConnection())
                return 1 == con.Execute(sql, classification);
        }
    }
}
