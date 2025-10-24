using System.Data;

namespace Recipes.Ado.Models;

public class EmployeeDetail : IEmployeeDetail
{
    public EmployeeDetail(IDataReader reader)
    {
        if (reader == null)
            throw new ArgumentNullException(nameof(reader), $"{nameof(reader)} is null.");

        EmployeeKey = reader.GetInt32(reader.GetOrdinal("EmployeeKey"));
        FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
        if (!reader.IsDBNull(reader.GetOrdinal("MiddleName")))
            MiddleName = reader.GetString(reader.GetOrdinal("MiddleName"));
        LastName = reader.GetString(reader.GetOrdinal("LastName"));
        if (!reader.IsDBNull(reader.GetOrdinal("Title")))
            Title = reader.GetString(reader.GetOrdinal("Title"));
        if (!reader.IsDBNull(reader.GetOrdinal("OfficePhone")))
            OfficePhone = reader.GetString(reader.GetOrdinal("OfficePhone"));
        if (!reader.IsDBNull(reader.GetOrdinal("CellPhone")))
            CellPhone = reader.GetString(reader.GetOrdinal("CellPhone"));
        EmployeeClassificationKey = reader.GetInt32(reader.GetOrdinal("EmployeeClassificationKey"));
        EmployeeClassificationName = reader.GetString(reader.GetOrdinal("EmployeeClassificationName"));
        IsExempt = reader.GetBoolean(reader.GetOrdinal("IsExempt"));
        IsEmployee = reader.GetBoolean(reader.GetOrdinal("IsEmployee"));
    }

    public string? CellPhone { get; set; }
    public int EmployeeClassificationKey { get; set; }
    public string? EmployeeClassificationName { get; set; }
    public int EmployeeKey { get; set; }
    public string? FirstName { get; set; }
    public bool IsEmployee { get; set; }
    public bool IsExempt { get; set; }
    public string? LastName { get; set; }
    public string? MiddleName { get; set; }
    public string? OfficePhone { get; set; }
    public string? Title { get; set; }
}