using Microsoft.Data.SqlClient;

namespace Recipes.Ado.Models;

public class Department : IDepartment
{
    public Department()
    {
    }

    public Department(SqlDataReader reader)
    {
        if (reader == null)
            throw new ArgumentNullException(nameof(reader), $"{nameof(reader)} is null.");

        DepartmentKey = reader.GetInt32(reader.GetOrdinal("DepartmentKey"));
        DepartmentName = reader.GetString(reader.GetOrdinal("DepartmentName"));
        DivisionKey = reader.GetInt32(reader.GetOrdinal("DivisionKey"));

        if (!reader.IsDBNull(reader.GetOrdinal("CreatedDate")))
            CreatedDate = reader.GetDateTime(reader.GetOrdinal("CreatedDate"));
        if (!reader.IsDBNull(reader.GetOrdinal("CreatedByEmployeeKey")))
            CreatedByEmployeeKey = reader.GetInt32(reader.GetOrdinal("CreatedByEmployeeKey"));

        if (!reader.IsDBNull(reader.GetOrdinal("ModifiedDate")))
            ModifiedDate = reader.GetDateTime(reader.GetOrdinal("ModifiedDate"));
        if (!reader.IsDBNull(reader.GetOrdinal("ModifiedByEmployeeKey")))
            ModifiedByEmployeeKey = reader.GetInt32(reader.GetOrdinal("ModifiedByEmployeeKey"));
    }

    public int DepartmentKey { get; set; }
    public string? DepartmentName { get; set; }
    public int DivisionKey { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public int? CreatedByEmployeeKey { get; set; }
    public int? ModifiedByEmployeeKey { get; set; }
    public bool IsDeleted { get; set; }
}