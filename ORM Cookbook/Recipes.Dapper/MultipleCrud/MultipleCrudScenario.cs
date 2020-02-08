using Dapper;
using Recipes.Dapper.Models;
using Recipes.MultipleCrud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recipes.Dapper.MultipleCrud
{
    public class MultipleCrudScenario : ScenarioBase, IMultipleCrudScenario<EmployeeSimple>
    {
        public MultipleCrudScenario(string connectionString) : base(connectionString)
        { }

        virtual public void DeleteBatch(IList<EmployeeSimple> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            var keyList = string.Join(", ", employees.Select(x => x.EmployeeKey));
            var sql = $"DELETE FROM HR.Employee WHERE EmployeeKey IN ({keyList});";

            using (var con = OpenConnection())
                con.Execute(sql);
        }

        public void DeleteBatchByKey(IList<int> employeeKeys)
        {
            if (employeeKeys == null || employeeKeys.Count == 0)
                throw new ArgumentException($"{nameof(employeeKeys)} is null or empty.", nameof(employeeKeys));

            var keyList = string.Join(", ", employeeKeys);
            var sql = $"DELETE FROM HR.Employee WHERE EmployeeKey IN ({keyList});";

            using (var con = OpenConnection())
                con.Execute(sql);
        }

        public IList<EmployeeSimple> FindByLastName(string lastName)
        {
            const string sql = "SELECT e.EmployeeKey, e.FirstName, e.MiddleName, e.LastName, e.Title, e.OfficePhone, e.CellPhone, e.EmployeeClassificationKey FROM HR.EmployeeDetail e WHERE e.LastName = @LastName";

            using (var con = OpenConnection())
                return con.Query<EmployeeSimple>(sql, new { lastName }).ToList();
        }

        virtual public void InsertBatch(IList<EmployeeSimple> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            var sql = new StringBuilder(@"INSERT INTO HR.Employee
(FirstName, MiddleName, LastName, Title, OfficePhone, CellPhone, EmployeeClassificationKey)
VALUES ");
            var parameters = new Dictionary<string, object?>();
            for (var i = 0; i < employees.Count; i++)
            {
                if (i != 0)
                    sql.AppendLine(",");
                sql.Append($"(@FirstName_{i}, @MiddleName_{i}, @LastName_{i}, @Title_{i}, @OfficePhone_{i}, @CellPhone_{i}, @EmployeeClassificationKey_{i})");

                parameters[$"@FirstName_{i}"] = employees[i].FirstName;
                parameters[$"@MiddleName_{i}"] = employees[i].MiddleName;
                parameters[$"@LastName_{i}"] = employees[i].LastName;
                parameters[$"@Title_{i}"] = employees[i].Title;
                parameters[$"@OfficePhone_{i}"] = employees[i].OfficePhone;
                parameters[$"@CellPhone_{i}"] = employees[i].CellPhone;
                parameters[$"@EmployeeClassificationKey_{i}"] = employees[i].EmployeeClassificationKey;
            }
            sql.AppendLine(";");

            //No transaction is needed because a single SQL statement is used.
            using (var con = OpenConnection())
                con.Execute(sql.ToString(), parameters);
        }

        public IList<int> InsertBatchReturnKeys(IList<EmployeeSimple> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            var sql = new StringBuilder(@"INSERT INTO HR.Employee
(FirstName, MiddleName, LastName, Title, OfficePhone, CellPhone, EmployeeClassificationKey)
OUTPUT Inserted.EmployeeKey
VALUES ");

            var parameters = new Dictionary<string, object?>();
            for (var i = 0; i < employees.Count; i++)
            {
                if (i != 0)
                    sql.AppendLine(",");
                sql.Append($"(@FirstName_{i}, @MiddleName_{i}, @LastName_{i}, @Title_{i}, @OfficePhone_{i}, @CellPhone_{i}, @EmployeeClassificationKey_{i})");

                parameters[$"@FirstName_{i}"] = employees[i].FirstName;
                parameters[$"@MiddleName_{i}"] = employees[i].MiddleName;
                parameters[$"@LastName_{i}"] = employees[i].LastName;
                parameters[$"@Title_{i}"] = employees[i].Title;
                parameters[$"@OfficePhone_{i}"] = employees[i].OfficePhone;
                parameters[$"@CellPhone_{i}"] = employees[i].CellPhone;
                parameters[$"@EmployeeClassificationKey_{i}"] = employees[i].EmployeeClassificationKey;
            }
            sql.AppendLine(";");

            //No transaction is needed because a single SQL statement is used.
            using (var con = OpenConnection())
                return con.Query<int>(sql.ToString(), parameters).ToList();
        }

        public IList<EmployeeSimple> InsertBatchReturnRows(IList<EmployeeSimple> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            var sql = new StringBuilder(@"INSERT INTO HR.Employee
(FirstName, MiddleName, LastName, Title, OfficePhone, CellPhone, EmployeeClassificationKey)
OUTPUT Inserted.EmployeeKey, Inserted.FirstName, Inserted.MiddleName, Inserted.LastName, Inserted.Title, Inserted.OfficePhone, Inserted.CellPhone, Inserted.EmployeeClassificationKey
VALUES ");

            var parameters = new Dictionary<string, object?>();
            for (var i = 0; i < employees.Count; i++)
            {
                if (i != 0)
                    sql.AppendLine(",");
                sql.Append($"(@FirstName_{i}, @MiddleName_{i}, @LastName_{i}, @Title_{i}, @OfficePhone_{i}, @CellPhone_{i}, @EmployeeClassificationKey_{i})");

                parameters[$"@FirstName_{i}"] = employees[i].FirstName;
                parameters[$"@MiddleName_{i}"] = employees[i].MiddleName;
                parameters[$"@LastName_{i}"] = employees[i].LastName;
                parameters[$"@Title_{i}"] = employees[i].Title;
                parameters[$"@OfficePhone_{i}"] = employees[i].OfficePhone;
                parameters[$"@CellPhone_{i}"] = employees[i].CellPhone;
                parameters[$"@EmployeeClassificationKey_{i}"] = employees[i].EmployeeClassificationKey;
            }
            sql.AppendLine(";");

            //No transaction is needed because a single SQL statement is used.
            using (var con = OpenConnection())
                return con.Query<EmployeeSimple>(sql.ToString(), parameters).ToList();
        }

        public void InsertBatchWithRefresh(IList<EmployeeSimple> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            var sql = new StringBuilder();

            //In order to ensure the right objects are refreshed, each object is inserted separately.
            //If we returned them all at the same time, they might not come back in the same order.
            var parameters = new Dictionary<string, object?>();
            for (var i = 0; i < employees.Count; i++)
            {
                sql.AppendLine($@"INSERT INTO HR.Employee
(FirstName, MiddleName, LastName, Title, OfficePhone, CellPhone, EmployeeClassificationKey)
OUTPUT Inserted.EmployeeKey, Inserted.FirstName, Inserted.MiddleName, Inserted.LastName, Inserted.Title, Inserted.OfficePhone, Inserted.CellPhone, Inserted.EmployeeClassificationKey
VALUES (@FirstName_{i}, @MiddleName_{i}, @LastName_{i}, @Title_{i}, @OfficePhone_{i}, @CellPhone_{i}, @EmployeeClassificationKey_{i});");

                parameters[$"@FirstName_{i}"] = employees[i].FirstName;
                parameters[$"@MiddleName_{i}"] = employees[i].MiddleName;
                parameters[$"@LastName_{i}"] = employees[i].LastName;
                parameters[$"@Title_{i}"] = employees[i].Title;
                parameters[$"@OfficePhone_{i}"] = employees[i].OfficePhone;
                parameters[$"@CellPhone_{i}"] = employees[i].CellPhone;
                parameters[$"@EmployeeClassificationKey_{i}"] = employees[i].EmployeeClassificationKey;
            }

            //A transaction is needed because this example uses multiple SQL statements.
            using (var con = OpenConnection())
            using (var trans = con.BeginTransaction())
            {
                var results = con.QueryMultiple(sql.ToString(), parameters, transaction: trans);

                for (var i = 0; i < employees.Count; i++)
                {
                    var temp = results.ReadSingle<EmployeeSimple>(); //each row is coming back as a separate result set
                    employees[i].Refresh(temp);
                }
            }
        }

        virtual public void UpdateBatch(IList<EmployeeSimple> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            var sql = new StringBuilder();

            var parameters = new Dictionary<string, object?>();
            for (var i = 0; i < employees.Count; i++)
            {
                sql.AppendLine($@"UPDATE HR.Employee
SET FirstName = @FirstName_{i},
    MiddleName = @MiddleName_{i},
    LastName = @LastName_{i},
    Title = @Title_{i},
    OfficePhone = @OfficePhone_{i},
    CellPhone = @CellPhone_{i},
    EmployeeClassificationKey = @EmployeeClassificationKey_{i}
WHERE EmployeeKey = @EmployeeKey_{i};");

                parameters[$"@EmployeeKey_{i}"] = employees[i].EmployeeKey;
                parameters[$"@FirstName_{i}"] = employees[i].FirstName;
                parameters[$"@MiddleName_{i}"] = employees[i].MiddleName;
                parameters[$"@LastName_{i}"] = employees[i].LastName;
                parameters[$"@Title_{i}"] = employees[i].Title;
                parameters[$"@OfficePhone_{i}"] = employees[i].OfficePhone;
                parameters[$"@CellPhone_{i}"] = employees[i].CellPhone;
                parameters[$"@EmployeeClassificationKey_{i}"] = employees[i].EmployeeClassificationKey;
            }

            //A transaction is needed because this example uses multiple SQL statements.
            using (var con = OpenConnection())
            using (var trans = con.BeginTransaction())
            {
                con.Execute(sql.ToString(), parameters, transaction: trans);
                trans.Commit();
            }
        }
    }
}
