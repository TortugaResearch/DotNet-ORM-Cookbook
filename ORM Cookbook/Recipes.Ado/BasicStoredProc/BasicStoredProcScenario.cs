using Microsoft.Data.SqlClient;
using Recipes.Ado.Models;
using Recipes.BasicStoredProc;
using System.Data;

namespace Recipes.Ado.BasicStoredProc;

public class BasicStoredProcScenario : SqlServerScenarioBase,
    IBasicStoredProcScenario<EmployeeClassification, EmployeeClassificationWithCount>
{
    public BasicStoredProcScenario(string connectionString) : base(connectionString)
    { }

    public IList<EmployeeClassificationWithCount> CountEmployeesByClassification()
    {
        using (var con = OpenConnection())
        using (var cmd = new SqlCommand("HR.CountEmployeesByClassification", con)
        { CommandType = CommandType.StoredProcedure })
        using (var reader = cmd.ExecuteReader())
        {
            var results = new List<EmployeeClassificationWithCount>();
            while (reader.Read())
                results.Add(new EmployeeClassificationWithCount(reader));

            return results;
        }
    }

    public int CreateEmployeeClassification(EmployeeClassification employeeClassification)
    {
        if (employeeClassification == null)
            throw new ArgumentNullException(nameof(employeeClassification),
                $"{nameof(employeeClassification)} is null.");

        using (var con = OpenConnection())
        using (var cmd = new SqlCommand("HR.CreateEmployeeClassification", con)
        { CommandType = CommandType.StoredProcedure })
        {
            cmd.Parameters.AddWithValue("@EmployeeClassificationName",
                    employeeClassification.EmployeeClassificationName);
            cmd.Parameters.AddWithValue("@IsEmployee", employeeClassification.IsEmployee);
            cmd.Parameters.AddWithValue("@IsExempt", employeeClassification.IsExempt);

            return (int)cmd.ExecuteScalar();
        }
    }

    public IList<EmployeeClassification> GetEmployeeClassifications()
    {
        using (var con = OpenConnection())
        using (var cmd = new SqlCommand("HR.GetEmployeeClassifications", con)
        { CommandType = CommandType.StoredProcedure })
        using (var reader = cmd.ExecuteReader())
        {
            var results = new List<EmployeeClassification>();
            while (reader.Read())
                results.Add(new EmployeeClassification(reader));

            return results;
        }
    }

    public EmployeeClassification? GetEmployeeClassifications(int employeeClassificationKey)
    {
        using (var con = OpenConnection())
        using (var cmd = new SqlCommand("HR.GetEmployeeClassifications", con)
        { CommandType = CommandType.StoredProcedure })
        {
            cmd.Parameters.AddWithValue("@EmployeeClassificationKey", employeeClassificationKey);
            using (var reader = cmd.ExecuteReader())
            {
                var results = new List<EmployeeClassification>();
                if (reader.Read())
                    return new EmployeeClassification(reader);
                else
                    return null;
            }
        }
    }
}