using Dapper;
using Recipes.Dapper.Models;
using Recipes.LargeBatch;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.Dapper.LargeBatch
{
    public class LargeBatchScenario : ScenarioBase, ILargeBatchScenario<EmployeeSimple>
    {
        public LargeBatchScenario(string connectionString) : base(connectionString)
        { }

        public int CountByLastName(string lastName)
        {
            const string sql = "SELECT Count(*) FROM HR.EmployeeDetail e WHERE e.LastName = @LastName";

            using (var con = OpenConnection())
                return con.ExecuteScalar<int>(sql, new { lastName });
        }

        public int MaximumBatchSize => 2100 / 7;

        virtual public void InsertLargeBatch(IList<EmployeeSimple> employees)
        {
            InsertLargeBatch(employees, 250);
        }

        virtual public void InsertLargeBatch(IList<EmployeeSimple> employees, int batchSize)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            using (var con = OpenConnection())
            using (var trans = con.BeginTransaction())
            {
                foreach (var batch in employees.BatchAsLists(batchSize))
                {
                    var sql = new StringBuilder(@"INSERT INTO HR.Employee
(FirstName, MiddleName, LastName, Title, OfficePhone, CellPhone, EmployeeClassificationKey)
VALUES ");
                    var parameters = new Dictionary<string, object?>();
                    for (var i = 0; i < batch.Count; i++)
                    {
                        if (i != 0)
                            sql.AppendLine(",");
                        sql.Append($"(@FirstName_{i}, @MiddleName_{i}, @LastName_{i}, @Title_{i}, @OfficePhone_{i}, @CellPhone_{i}, @EmployeeClassificationKey_{i})");

                        parameters[$"@FirstName_{i}"] = batch[i].FirstName;
                        parameters[$"@MiddleName_{i}"] = batch[i].MiddleName;
                        parameters[$"@LastName_{i}"] = batch[i].LastName;
                        parameters[$"@Title_{i}"] = batch[i].Title;
                        parameters[$"@OfficePhone_{i}"] = batch[i].OfficePhone;
                        parameters[$"@CellPhone_{i}"] = batch[i].CellPhone;
                        parameters[$"@EmployeeClassificationKey_{i}"] = batch[i].EmployeeClassificationKey;
                    }
                    sql.AppendLine(";");

                    con.Execute(sql.ToString(), parameters, transaction: trans);
                }
                trans.Commit();
            }
        }
    }
}
