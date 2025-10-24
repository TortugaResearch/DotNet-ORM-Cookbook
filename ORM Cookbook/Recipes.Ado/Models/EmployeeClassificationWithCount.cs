using Microsoft.Data.SqlClient;

namespace Recipes.Ado.Models;

public class EmployeeClassificationWithCount : IEmployeeClassificationWithCount
{
    public EmployeeClassificationWithCount(SqlDataReader reader)
    {
        if (reader == null)
            throw new ArgumentNullException(nameof(reader), $"{nameof(reader)} is null.");

        EmployeeClassificationKey = reader.GetInt32(reader.GetOrdinal("EmployeeClassificationKey"));
        EmployeeClassificationName = reader.GetString(reader.GetOrdinal("EmployeeClassificationName"));
        EmployeeCount = reader.GetInt32(reader.GetOrdinal("EmployeeCount"));
    }

    public int EmployeeClassificationKey { get; set; }
    public string? EmployeeClassificationName { get; set; }
    public int EmployeeCount { get; set; }
}