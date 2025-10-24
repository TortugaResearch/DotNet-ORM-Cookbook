using Microsoft.Data.SqlClient;
using Recipes.Ado.Models;
using Recipes.Views;

namespace Recipes.Ado.Views;

public class ViewsScenario : SqlServerScenarioBase, IViewsScenario<EmployeeDetail, EmployeeSimple>
{
    public ViewsScenario(string connectionString) : base(connectionString)
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
        const string sql = "SELECT ed.EmployeeKey, ed.FirstName, ed.MiddleName, ed.LastName, ed.Title, ed.OfficePhone, ed.CellPhone, ed.EmployeeClassificationKey, ed.EmployeeClassificationName, ed.IsExempt, ed.IsEmployee FROM HR.EmployeeDetail ed WHERE ed.EmployeeClassificationKey = @EmployeeClassificationKey";

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
        const string sql = "SELECT ed.EmployeeKey, ed.FirstName, ed.MiddleName, ed.LastName, ed.Title, ed.OfficePhone, ed.CellPhone, ed.EmployeeClassificationKey, ed.EmployeeClassificationName, ed.IsExempt, ed.IsEmployee FROM HR.EmployeeDetail ed WHERE ed.LastName = @LastName";

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
        const string sql = "SELECT ed.EmployeeKey, ed.FirstName, ed.MiddleName, ed.LastName, ed.Title, ed.OfficePhone, ed.CellPhone, ed.EmployeeClassificationKey, ed.EmployeeClassificationName, ed.IsExempt, ed.IsEmployee FROM HR.EmployeeDetail ed WHERE ed.EmployeeKey = @EmployeeKey";

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