using Microsoft.Data.SqlClient;
using Recipes.Ado.Models;
using Recipes.Joins;

namespace Recipes.Ado.Joins;

public class JoinsScenario : SqlServerScenarioBase, IJoinsScenario<EmployeeDetail, EmployeeSimple>
{
    public JoinsScenario(string connectionString) : base(connectionString)
    { }

    public int Create(EmployeeSimple employee)
    {
        if (employee == null)
            throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

        const string sql = @"INSERT INTO HR.Employee
(FirstName, MiddleName, LastName, Title, OfficePhone, CellPhone, EmployeeClassificationKey)
OUTPUT Inserted.EmployeeKey
VALUES
(@FirstName, @MiddleName, @LastName, @Title, @OfficePhone, @CellPhone, @EmployeeClassificationKey);";

        using (var con = OpenConnection())
        using (var cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
            cmd.Parameters.AddWithValue("@MiddleName", (object?)employee.MiddleName ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@LastName", employee.LastName);
            cmd.Parameters.AddWithValue("@Title", (object?)employee.Title ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@OfficePhone", (object?)employee.OfficePhone ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@CellPhone", (object?)employee.CellPhone ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@EmployeeClassificationKey", employee.EmployeeClassificationKey);

            return (int)cmd.ExecuteScalar();
        }
    }

    public IList<EmployeeDetail> FindByEmployeeClassificationKey(int employeeClassificationKey)
    {
        const string sql = "SELECT e.EmployeeKey, e.FirstName, e.MiddleName, e.LastName, e.Title, e.OfficePhone, e.CellPhone, e.EmployeeClassificationKey, ec.EmployeeClassificationName, ec.IsExempt, ec.IsEmployee FROM HR.Employee e INNER JOIN HR.EmployeeClassification ec ON e.EmployeeClassificationKey = ec.EmployeeClassificationKey WHERE e.EmployeeClassificationKey = @EmployeeClassificationKey";

        using (var con = OpenConnection())
        using (var cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@EmployeeClassificationKey", employeeClassificationKey);

            var results = new List<EmployeeDetail>();

            using (var reader = cmd.ExecuteReader())
                while (reader.Read())
                    results.Add(new EmployeeDetail(reader));

            return results;
        }
    }

    public IList<EmployeeDetail> FindByLastName(string lastName)
    {
        const string sql = "SELECT e.EmployeeKey, e.FirstName, e.MiddleName, e.LastName, e.Title, e.OfficePhone, e.CellPhone, e.EmployeeClassificationKey, ec.EmployeeClassificationName, ec.IsExempt, ec.IsEmployee FROM HR.Employee e INNER JOIN HR.EmployeeClassification ec ON e.EmployeeClassificationKey = ec.EmployeeClassificationKey WHERE e.LastName = @LastName";

        using (var con = OpenConnection())
        using (var cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@LastName", lastName);

            var results = new List<EmployeeDetail>();

            using (var reader = cmd.ExecuteReader())
                while (reader.Read())
                    results.Add(new EmployeeDetail(reader));

            return results;
        }
    }

    public EmployeeDetail? GetByEmployeeKey(int employeeKey)
    {
        const string sql = "SELECT e.EmployeeKey, e.FirstName, e.MiddleName, e.LastName, e.Title, e.OfficePhone, e.CellPhone, e.EmployeeClassificationKey, ec.EmployeeClassificationName, ec.IsExempt, ec.IsEmployee FROM HR.Employee e INNER JOIN HR.EmployeeClassification ec ON e.EmployeeClassificationKey = ec.EmployeeClassificationKey WHERE e.EmployeeKey = @EmployeeKey";

        using (var con = OpenConnection())
        using (var cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@EmployeeKey", employeeKey);

            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                    return new EmployeeDetail(reader);
                else
                    return null;
            }
        }
    }

    public IEmployeeClassification? GetClassification(int employeeClassificationKey)
    {
        const string sql = "SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName, ec.IsExempt, ec.IsEmployee FROM HR.EmployeeClassification ec WHERE EmployeeClassificationKey = @EmployeeClassificationKey";

        using (var con = OpenConnection())
        using (var cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@EmployeeClassificationKey", employeeClassificationKey);

            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                    return new EmployeeClassification(reader);
                else
                    return null;
            }
        }
    }
}