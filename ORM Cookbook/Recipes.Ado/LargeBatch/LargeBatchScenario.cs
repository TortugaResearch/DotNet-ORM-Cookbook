using Microsoft.Data.SqlClient;
using Recipes.Ado.Models;
using Recipes.LargeBatch;
using System.Text;

namespace Recipes.Ado.LargeBatch;

public class LargeBatchScenario : SqlServerScenarioBase, ILargeBatchScenario<EmployeeSimple>
{
    public LargeBatchScenario(string connectionString) : base(connectionString)
    { }

    public int CountByLastName(string lastName)
    {
        const string sql = "SELECT Count(*) FROM HR.EmployeeDetail e WHERE e.LastName = @LastName";
        using (var con = OpenConnection())
        using (var cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@LastName", lastName);
            return (int)cmd.ExecuteScalar();
        }
    }

    public int MaximumBatchSize => 2100 / 7;

    public void InsertLargeBatch(IList<EmployeeSimple> employees)
    {
        InsertLargeBatch(employees, 250);
    }

    public void InsertLargeBatch(IList<EmployeeSimple> employees, int batchSize)
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

                for (var i = 0; i < batch.Count; i++)
                {
                    if (i != 0)
                        sql.AppendLine(",");
                    sql.Append($"(@FirstName_{i}, @MiddleName_{i}, @LastName_{i}, @Title_{i}, @OfficePhone_{i}, @CellPhone_{i}, @EmployeeClassificationKey_{i})");
                }
                sql.AppendLine(";");

                using (var cmd = new SqlCommand(sql.ToString(), con, trans))
                {
                    for (var i = 0; i < batch.Count; i++)
                    {
                        cmd.Parameters.AddWithValue($"@FirstName_{i}", batch[i].FirstName);
                        cmd.Parameters.AddWithValue($"@MiddleName_{i}", (object?)batch[i].MiddleName ?? DBNull.Value);
                        cmd.Parameters.AddWithValue($"@LastName_{i}", batch[i].LastName);
                        cmd.Parameters.AddWithValue($"@Title_{i}", (object?)batch[i].Title ?? DBNull.Value);
                        cmd.Parameters.AddWithValue($"@OfficePhone_{i}", (object?)batch[i].OfficePhone ?? DBNull.Value);
                        cmd.Parameters.AddWithValue($"@CellPhone_{i}", (object?)batch[i].CellPhone ?? DBNull.Value);
                        cmd.Parameters.AddWithValue($"@EmployeeClassificationKey_{i}", batch[i].EmployeeClassificationKey);
                    }
                    cmd.ExecuteNonQuery();
                }
            }
            trans.Commit();
        }
    }
}